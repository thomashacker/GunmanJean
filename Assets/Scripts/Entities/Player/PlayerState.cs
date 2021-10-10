using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("States")]
    [SerializeField] private int looking_dir;
    [SerializeField] private int moving_dir;
    [SerializeField] private int vertical_dir;
    [SerializeField] private float rotation_z;
    [SerializeField] private bool moving;
    [SerializeField] private bool on_ground;

    [Header("Raycast")]
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float ground_ray_offset;

    [Header("Rotation")]
    [SerializeField] private float rotation_offset;

    [Header("Mouse")]
    [SerializeField] private Vector2 current_pos;
    [SerializeField] private Vector2 mouse_pos;
    [SerializeField] private Vector2 diff_pos;

    private Rigidbody2D body;
    private CapsuleCollider2D collider;

    void Start()
    {
        init_components();
    }

    // Update is called once per frame
    void Update()
    {
        mouseRotation();
        detect_look_dir();
        detect_vertical_dir();
        detect_moving();
        detect_ground();
    }

    // Initialize Components
    private void init_components()
    {
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    // Get Rotation based between mouse position and current player position
    private void mouseRotation()
    {
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
    }

    // Check whether the mouse is right or left of the player
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

    // Check whether the player is moving
    private void detect_moving()
    {
        if(body.velocity.magnitude > 0.1) { moving = true; } else { moving = false; }
        if (moving)
        {
            if(body.velocity.x > 0) { moving_dir = 1; }
            else if(body.velocity.x < 0) { moving_dir = -1; }
        }
    }

    // Check whether the player is on the ground
    private void detect_ground()
    {
        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center, Vector2.down, collider.bounds.extents.y + ground_ray_offset, layerMask);
        Color rayColor;

        if(hit.collider != null)
        {
            rayColor = Color.green;
            on_ground = true;
        } else
        {
            rayColor = Color.red;
            on_ground = false;
        }

        Debug.DrawRay(collider.bounds.center, Vector2.down * (collider.bounds.extents.y + ground_ray_offset), rayColor);

    }

    // Check whether the players vertical looking direction
    private void detect_vertical_dir()
    {
        if (rotation_z <= 165 && rotation_z >= 15)
        {
            vertical_dir = 1;
        }
        else if(rotation_z >= -165 && rotation_z <= -15)
        {
            vertical_dir = -1;
        }
        else
        {
            vertical_dir = 0;
        }
    }

    // Getter & Setter

    public bool get_moving()
    {
        return moving;
    }

    public int get_moving_dir()
    {
        return moving_dir;
    }

    public bool get_on_ground()
    {
        return on_ground;
    }

    public int get_vertical_dir()
    {
        return vertical_dir;
    }

    public int get_dir()
    {
        return looking_dir;
    }

    public Vector2 get_diff_pos()
    {
        return diff_pos;
    }

}
