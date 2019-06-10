using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        // start parameters
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // if started by tap, start to scroll bacground
        if (GameControl.instance.started == true)
        {
            rb2d = GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector2(GameControl.instance.scrollSpeed, 0);
        }

        // if game is over, stop scrolling
        if (GameControl.instance.gameOver == true)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.MoveRotation(rb2d.rotation + 0 * Time.fixedDeltaTime);
        }
    }
}
