using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBrakes : ShipComponent
{
    public float dampeningFactor = 0.1f;
    public float activePowerUsage = 0.1f;

    private Rigidbody2D shipBody;

    // Use this for initialization
    void Start()
    {
        shipBody = GameObject.Find("ship").GetComponent<Rigidbody2D>();
        IsActivated = false;
    }

    public override float ProcessForFrame(ShipController ship, float elapsedTime)
    {
        if (!ship.IsWorking) { IsActivated = false; }
        else if (Input.GetKeyDown(controlKey)) { IsActivated = !IsActivated; }

        if (IsActivated)
        {
            shipBody.velocity = (1f - (dampeningFactor * Time.deltaTime)) * shipBody.velocity;
            shipBody.angularVelocity = (1f - (dampeningFactor * Time.deltaTime)) * shipBody.angularVelocity;
        }

        return (IsActivated ? activePowerUsage : 0f) * elapsedTime;
    }
}
