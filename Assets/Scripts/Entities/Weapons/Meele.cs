using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meele : MonoBehaviour, Weapon
{

    private PlayerState playerState;
    private Animator anim;

    private int combo_counter = 0;


    // Start is called before the first frame update
    void Start()
    {
        combo_counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(anim != null) { set_anim(); }
    }

    // Initialize Components
    public void init_components(PlayerState _playerState)
    {
        anim = GetComponent<Animator>();
        playerState = _playerState;
    }


    public void trigger_primary()
    {
        if(combo_counter == 0)
        {
            anim.Play("Meele_1");
            combo_counter = 1;
        } else if (combo_counter == 1)
        {
            anim.Play("Meele_2");
            combo_counter = 0;
        }
    }

    public void trigger_secondary()
    {
        Debug.Log("Triggered secondary");

    }

    private void set_anim()
    {
        anim.SetBool("moving", playerState.get_moving());
        anim.SetBool("grounded", playerState.get_on_ground());
        anim.SetFloat("looking_dir", playerState.get_dir());
        anim.SetFloat("moving_dir", playerState.get_moving_dir());
    }
}
