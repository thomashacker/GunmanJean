using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [Header("Animation Speed")]
    [SerializeField] private float flip_time;

    [Header("Shadow")]
    [SerializeField] private GameObject shadow;
    [SerializeField] private float y_offset;
    [SerializeField] private LayerMask layerMask;

    [Header("Bodypart")]
    public Animator head_anim;
    public Animator body_anim;

    private PlayerState playerState;
    private CapsuleCollider2D collider;

    [Header("Debugging")]
    [SerializeField] private string hit_name;
    [SerializeField] private Vector3 hit_vector;

    // Start is called before the first frame update
    void Start()
    {
        init_components();
    }

    // Update is called once per frame
    void Update()
    {
        flip_player();
        body_animation();
        head_animation();
        place_shadow();
    }

    // Initialize Components
    private void init_components()
    {
        playerState = GetComponent<PlayerState>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    private void flip_player()
    {
        int current_dir = playerState.get_dir();
        if(current_dir == 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-1, transform.localScale.y, transform.localScale.z), Time.deltaTime * flip_time);
        }else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, transform.localScale.y, transform.localScale.z), Time.deltaTime * flip_time);
        }
    }

    private void body_animation()
    {
        body_anim.SetBool("moving", playerState.get_moving());
        body_anim.SetBool("grounded", playerState.get_on_ground());
        body_anim.SetFloat("looking_dir", playerState.get_dir());
        body_anim.SetFloat("moving_dir", playerState.get_moving_dir());
    }

    private void head_animation()
    {
        head_anim.SetFloat("looking_vertical_dir", playerState.get_vertical_dir());
    }

    private void place_shadow()
    {
        RaycastHit2D hit = Physics2D.Raycast(collider.bounds.center, Vector2.down, 100f, layerMask);
        shadow.transform.position = new Vector2(shadow.transform.position.x, hit.point.y+ y_offset);

        Debug.DrawRay(collider.bounds.center+new Vector3(1f,0f,0f), Vector2.down * 100, Color.blue);

        hit_name = hit.collider.gameObject.name;
        hit_vector = hit.point;

    }


}
