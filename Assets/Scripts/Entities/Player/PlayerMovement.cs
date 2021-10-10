using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /* This script handles the Player's movements
    *
    */

    [Header("Movement Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float jump_power;

    private PlayerInput playerInput;
    private PlayerState playerState;
    private Rigidbody2D body;
    private CapsuleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        init_components();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        move_player();
        jump_player();
    }

    private void init_components()
    {
        playerInput = GetComponent<PlayerInput>();
        playerState = GetComponent<PlayerState>();
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    private void move_player()
    {
        body.velocity = new Vector2(playerInput.get_horizontal() * speed, body.velocity.y);
    }

    private void jump_player()
    {
        bool grounded = playerState.get_on_ground();

        if (grounded && playerInput.get_space())
        {
            body.AddForce(Vector2.up * jump_power);
        } else if(!grounded && playerInput.get_key_s())
        {
            body.AddForce(Vector2.down * (jump_power/2));
        }
    }

}
