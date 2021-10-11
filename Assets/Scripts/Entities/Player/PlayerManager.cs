using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update



    private PlayerEquip playerEquip;
    private PlayerInput playerInput;
    private PlayerState playerState;


    void Start()
    {
        init_components();
    }

    // Update is called once per frame
    void Update()
    {
        attack();
    }

    // Initialize Components
    private void init_components()
    {
        playerInput = GetComponent<PlayerInput>();
        playerEquip = GetComponentInChildren<PlayerEquip>();
        playerState = GetComponent<PlayerState>();
        playerEquip.init_components(playerState);
    }

    private void attack()
    {
        if (playerInput.get_mouse_p())
        {
            playerEquip.trigger_primary();
        } else if (playerInput.get_mouse_s())
        {
            playerEquip.trigger_secondary();
        }
    }

}
