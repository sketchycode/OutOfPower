using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupport : ShipComponent
{
    public float activePowerUsage = 0.5f;
    public float crewHealthDecay = 0.1f;
    public float crewHealthRecoverRate = 0.02f;

    private void Start()
    {
        IsActivated = true;
    }

    public override float ProcessForFrame(ShipController ship, float elapsedTime)
    {
        if (!ship.IsWorking) { IsActivated = false; }
        else if (Input.GetKeyDown(controlKey)) { IsActivated = !IsActivated; }

        ship.crewHealth += (IsActivated ? crewHealthRecoverRate : -crewHealthDecay) * elapsedTime;

        return (IsActivated ? activePowerUsage : 0f) * elapsedTime;
    }

    public override void Reset()
    {
        base.Reset();
        IsActivated = true;
    }
}
