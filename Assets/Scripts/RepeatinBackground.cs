using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatinBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameControl.instance.started == true)
        {
            if (transform.position.x <= -(groundHorizontalLength - 0.25f))
            {
                RepositionBackground();
            }
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0);
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
