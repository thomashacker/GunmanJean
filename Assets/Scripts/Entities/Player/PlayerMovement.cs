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

    private PlayerInput playerInput;
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
    }

    private void init_components()
    {
        playerInput = GetComponent<PlayerInput>();
        body = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();
    }

    private void move_player()
    {
        body.velocity = new Vector2(playerInput.get_horizontal() * speed, body.velocity.y);
    }

}
