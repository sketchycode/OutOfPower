using System.Collections;
using System;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public event EventHandler Destroyed;

    public ParticleSystem explosionEffect;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        HandleTriggerEntered(collider);
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        HandleTriggerEntered(collider);
    }

    private void HandleTriggerEntered(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var shields = collider.gameObject.GetComponent<Shields>();
            if (shields.IsActivated)
            {
                var effect = Instantiate(explosionEffect, transform.position, Quaternion.identity);
                effect.Play();
                if (Destroyed != null)
                {
                    Destroyed(this, EventArgs.Empty);
                }
            }
        }
    }
}
