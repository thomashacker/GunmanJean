using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    /* This script follows the player
     *
     */

    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private float y_offset;
    [SerializeField] private float y_mouse_offset;
    [SerializeField] private float x_mouse_offset;

    private GameObject follow_object;
    private BoxCollider2D bounds;

    //Bounds
    private Vector2 min_bounds;
    private Vector2 max_bounds;
    private float half_width;
    private float half_height;

    private PlayerState playerState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        if (follow_object != null) { move_to_object(); }
    }

    private void move_to_object()
    {
        float y_offset_ = y_offset + Mathf.Clamp(playerState.get_diff_pos().y, -y_mouse_offset, y_mouse_offset);
        float x_offset_ = Mathf.Clamp(playerState.get_diff_pos().x, -x_mouse_offset, x_mouse_offset);
        Vector2 desiredPos = follow_object.transform.position;
        Vector2 smoothedPos = Vector2.Lerp(transform.position, desiredPos+new Vector2(x_offset_, y_offset_), speed * Time.deltaTime);
        transform.position = new Vector3(smoothedPos.x, smoothedPos.y, -15);
        stay_in_bound();
    }

    public void set_player(GameObject obj, GameObject _bounds)
    {
        follow_object = obj;
        playerState = obj.GetComponent<PlayerState>();
        bounds = _bounds.GetComponent<BoxCollider2D>();

        min_bounds = bounds.bounds.min;
        max_bounds = bounds.bounds.max;

        half_height = this.GetComponent<Camera>().orthographicSize;
        half_width = half_height * Screen.width / Screen.height;

    }

    private void stay_in_bound()
    {
        float clampedX = Mathf.Clamp(transform.position.x, min_bounds.x + half_width, max_bounds.x - half_width);
        float clampedY = Mathf.Clamp(transform.position.y, min_bounds.y + half_height, max_bounds.y - half_height);

        transform.position = new Vector3(clampedX, clampedY, transform.position.z);
    }
}
