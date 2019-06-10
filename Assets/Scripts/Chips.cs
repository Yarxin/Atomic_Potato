using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chips : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Potato>() != null)
        {
            GameControl.instance.AddTime();
            gameObject.SetActive(false);
        }
    }
}
