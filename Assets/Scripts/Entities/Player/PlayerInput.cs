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

    // Update is called once per frame
    void Update()
    {
        listen_horizontal();
        listen_vertical();
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

    public float get_horizontal()
    {
        return horizontal_input;
    }

    public float get_vertical()
    {
        return vertical_input;
    }


}
