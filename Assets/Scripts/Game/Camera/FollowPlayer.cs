using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /* This script follows the player
     *
     */

    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float y_offset;
    [SerializeField] private float y_mouse_offset;
    [SerializeField] private float x_mouse_offset;

    private GameObject follow_object;

    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (follow_object != null) { move_to_object(); }
    }

    private void move_to_object()
    {
        float y_offset_ = y_offset + Mathf.Clamp(playerState.get_diff_pos().y, -y_mouse_offset, y_mouse_offset);
        float x_offset_ = Mathf.Clamp(playerState.get_diff_pos().x, -x_mouse_offset, x_mouse_offset);
        Vector2 desiredPos = follow_object.transform.position;
        Vector2 smoothedPos = Vector2.Lerp(transform.position, desiredPos+new Vector2(x_offset_, y_offset_), speed * Time.deltaTime);
        transform.position = new Vector3(smoothedPos.x, smoothedPos.y, -10);
    }

    public void set_player(GameObject obj)
    {
        follow_object = obj;
        playerState = obj.GetComponent<PlayerState>();
    }
}
