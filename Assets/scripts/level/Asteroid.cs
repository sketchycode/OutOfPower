using System.Collections;
using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public event EventHandler Destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            var shields = collision.gameObject.GetComponent<Shields>();
            if(shields.IsActivated)
            {
                if(Destroyed != null)
                {
                    Destroyed(this, EventArgs.Empty);
                }
            }
        }
    }
}
