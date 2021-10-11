using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{
    [Header("Graphical Indicator")]
    [SerializeField] private GameObject indicator;


    private PlayerState playerState;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState != null) { rotate(); }
    }

    // Initialize Components
    public void init_components(float offset, PlayerState _playerState)
    {
        playerState = _playerState;
        indicator.transform.position = new Vector2(indicator.transform.position.x + offset, indicator.transform.position.y);
    }

    private void rotate()
    {
        transform.rotation = Quaternion.Euler(0f, 0f, playerState.get_rotation_z() + playerState.get_offset());
    }

}
