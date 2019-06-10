using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fries : MonoBehaviour
{
    public static Fries instance;
    public bool isEaten;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Potato>() != null)
        {
            GameControl.instance.PotatoScored();
            gameObject.SetActive(false);
            isEaten = true;
        }
    }
}
