using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquip : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Weapons")]
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private GameObject cursor;
    [SerializeField] private float cursor_x_offset;
    [SerializeField] private GameObject current_weapon;

    private PlayerState playerState;


    void Start()
    {
        current_weapon = weapons[0];
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Initialize Components
    public void init_components(PlayerState _playerState)
    {
        playerState = _playerState;
        foreach(GameObject weapon in weapons)
        {
            weapon.GetComponent<Weapon>().init_components(_playerState);
        }
        cursor.GetComponent<Cursor>().init_components(cursor_x_offset,_playerState);
    }

    public void trigger_primary()
    {
        current_weapon.GetComponent<Weapon>().trigger_primary();
    }

    public void trigger_secondary()
    {
        current_weapon.GetComponent<Weapon>().trigger_secondary();
    }


}
