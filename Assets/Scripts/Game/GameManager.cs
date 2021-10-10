using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Vector2 spawnPos;

    [Header("Bounds")]
    [SerializeField] private GameObject camera_bounds;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        init_components();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Initialize Components
    private void init_components()
    {
        cam = Camera.main;
        GameObject playerObj = Instantiate(playerPrefab, spawnPos, Quaternion.identity);
        cam.GetComponent<FollowPlayer>().set_player(playerObj, camera_bounds);
    }
}
