using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeEnter : MonoBehaviour
{
    [Header("Configuration")]
    [SerializeField] private float fade_speed;


    private SpriteRenderer renderer;
    private BoxCollider2D collider;

    [Header("Debugging")]
    [SerializeField] private bool entityInside;



    // Start is called before the first frame update
    void Start()
    {
        init_components();
    }

    // Update is called once per frame
    void Update()
    {
        fade();
    }

    // Initialize Components
    private void init_components()
    {
        renderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            entityInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            entityInside = false;
        }
    }

    private void fade()
    {
        if (entityInside)
        {
            renderer.color = Color.Lerp(renderer.color, new Color(renderer.color.r, renderer.color.g, renderer.color.b, 0),Time.deltaTime*fade_speed);
        } else
        {
            renderer.color = Color.Lerp(renderer.color, new Color(renderer.color.r, renderer.color.g, renderer.color.b, 1), Time.deltaTime * fade_speed);
        }
    }

}
