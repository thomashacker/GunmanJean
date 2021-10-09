using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    [Header("Animation Speed")]
    [SerializeField] private float flip_time;

    [Header("Bodypart")]
    public Animator head_anim;
    public Animator arms_anim;
    public Animator body_anim;

    private PlayerState playerState;

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
    }

    // Initialize Components
    private void init_components()
    {
        playerState = GetComponent<PlayerState>();
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
        body_anim.SetFloat("looking_dir", playerState.get_dir());
        body_anim.SetFloat("moving_dir", playerState.get_moving_dir());
    }


}
