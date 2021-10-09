using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("States")]
    [SerializeField] private int looking_dir;
    [SerializeField] private int moving_dir;
    [SerializeField] private float rotation_z;
    [SerializeField] private bool moving;


    [Header("Rotation")]
    [SerializeField] private float rotation_offset;

    [Header("Mouse")]
    [SerializeField] private Vector2 current_pos;
    [SerializeField] private Vector2 mouse_pos;
    [SerializeField] private Vector2 diff_pos;

    private Rigidbody2D body;

    void Start()
    {
        init_components();
    }

    // Initialize Components
    private void init_components()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotation();
        detect_look_dir();
        detect_moving();
    }

    private void mouseRotation()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    }

    private void detect_look_dir()
    {
        current_pos = transform.position;
        mouse_pos = Input.mousePosition;

        mouse_pos = Camera.main.ScreenToWorldPoint(mouse_pos);
        diff_pos = mouse_pos - current_pos;

        if (diff_pos.x > 0)
        {
            looking_dir = 1;
            rotation_offset = 0;
        }

        else if (diff_pos.x < 0)
        {
            looking_dir = -1;
            rotation_offset = 180; ;
        }

    }

    public int get_dir()
    {
        return looking_dir;
    }

    public Vector2 get_diff_pos()
    {
        return diff_pos;
    }

    private void detect_moving()
    {
        if(body.velocity.magnitude > 0) { moving = true; } else { moving = false; }
        if (moving)
        {
            if(body.velocity.x > 0) { moving_dir = 1; }
            else if(body.velocity.x < 0) { moving_dir = -1; }
        }
    }

    public bool get_moving()
    {
        return moving;
    }

    public int get_moving_dir()
    {
        return moving_dir;
    }

}
