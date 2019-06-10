using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
    public float upForce = 300f;
    public float rightForce = 5f;
    public float leftForce = -2.5f;

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    private Vector2 velocity;
    private float revSpeed = -300.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (GameControl.instance.started == true)
            {
                // they see me rollin', they hatin' Patrolling and tryin' to catch me ridin' dirty
                rb2d.MoveRotation(rb2d.rotation + revSpeed * Time.fixedDeltaTime);

                ////centering the potato position.
                if (rb2d.position.x < 0)
                {
                    rb2d.AddForce(new Vector2(rightForce, 0));
                }
                if (rb2d.position.x > 0)
                {
                    rb2d.AddForce(new Vector2(leftForce, 0));
                }

                if (Input.GetMouseButtonDown(0))
                {
                    rb2d.velocity = Vector2.zero;
                    rb2d.AddForce(new Vector2(0, upForce));
                }
            }
        }
    }
}
