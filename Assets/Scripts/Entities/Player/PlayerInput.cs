using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    /* This script handles all Player Inputs
     *
     */


    [Header("Input")]
    [SerializeField] private float horizontal_input;
    [SerializeField] private float vertical_input;
    [SerializeField] private bool space;
    [SerializeField] private bool key_s;
    [SerializeField] private bool mouse_p;
    [SerializeField] private bool mouse_s;

    // Update is called once per frame
    void Update()
    {
        listen_mouse();
        listen_horizontal();
        listen_vertical();
        listen_key();
    }

    // Listen to horizontal inputs
    private void listen_horizontal()
    {
        horizontal_input = Input.GetAxis("Horizontal");
    }

    // Listen to vertical inputs
    private void listen_vertical()
    {
        vertical_input = Input.GetAxis("Vertical");
    }

    private void listen_key()
    {
        key_s = Input.GetKey(KeyCode.S);
        space = Input.GetKey(KeyCode.Space);
    }

    private void listen_mouse()
    {
        mouse_p = Input.GetMouseButtonDown(0);
        mouse_s = Input.GetMouseButtonDown(1);
    }

    public float get_horizontal()
    {
        return horizontal_input;
    }

    public float get_vertical()
    {
        return vertical_input;
    }

    public bool get_space()
    {
        return space;
    }

    public bool get_key_s()
    {
        return key_s;
    }

    public bool get_mouse_p()
    {
        return mouse_p;
    }

    public bool get_mouse_s()
    {
        return mouse_s;
    }




}
