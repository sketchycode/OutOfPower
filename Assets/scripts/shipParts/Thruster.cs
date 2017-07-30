using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thruster : ShipComponent
{
    public float activePowerUsage = 0.5f;
    public float power = 4f;

    public override float ProcessForFrame(ShipController ship, float elapsedTime)
    {
        var shipBody = ship.GetComponent<Rigidbody2D>();

        var powerUsed = 0f;
        IsActivated = false;
        if (Input.GetKey(controlKey) && ship.IsWorking)
        {
            shipBody.AddForceAtPosition(transform.rotation * (power * Vector2.up), transform.position);
            powerUsed = activePowerUsage * elapsedTime;
            IsActivated = true;
        }

        return powerUsed;
    }
}
