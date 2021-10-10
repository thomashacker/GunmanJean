using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    [Header("Layers")]
    [SerializeField] private Transform[] backgrounds;
    [SerializeField] private float dynamic = 1;

    private float[] parallax_scale;
    private Camera cam;
    private Vector3 prev_cam_pos;

    // Start is called before the first frame update
    void Start()
    {
        init_components();
        setup_parralax();
    }

    private void Update()
    {
        apply_effect();
    }

    // Initialize Components
    private void init_components()
    {
        cam = Camera.main;
    }

    private void setup_parralax()
    {
        prev_cam_pos = cam.transform.position;
        parallax_scale = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++)
        {
            parallax_scale[i] = backgrounds[i].position.z * -1;
        }
    }

    private void apply_effect()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {

            float parallax = (prev_cam_pos.x - cam.transform.position.x) * parallax_scale[i];
            float backgroundTargetPosX = backgrounds[i].position.x + parallax;
            Vector2 backgroundTargetPos = new Vector2(backgroundTargetPosX, backgrounds[i].position.y);
            backgrounds[i].position = Vector2.Lerp(backgrounds[i].position, backgroundTargetPos, dynamic * Time.deltaTime);
        }

        prev_cam_pos = cam.transform.position;
    }

    
}
