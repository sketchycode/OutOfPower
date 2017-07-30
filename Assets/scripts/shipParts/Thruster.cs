using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ShipComponent
{
    public float activePowerUsage = 0.5f;
    public float power = 4f;

    private Rigidbody2D shipBody;

    private void Start()
    {
        shipBody = GameObject.Find("ship").GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        powerUsage = 0;
        if(Input.GetKey(controlKey))
        {
            powerUsage = activePowerUsage;
            shipBody.AddForceAtPosition(transform.rotation * (power * Vector2.up), transform.position);
        }
    }
}
