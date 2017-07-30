using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HullRepair : ShipComponent
{
    public float activePowerUsage = 0.4f;
    public float hullRepairRate = 0.05f;

    public override float ProcessForFrame(ShipController ship, float elapsedTime)
    {
        if (!ship.IsWorking) { IsActivated = false; }
        else if (Input.GetKeyDown(controlKey)) { IsActivated = !IsActivated; }

        var powerUsed = 0f;
        if (IsActivated && ship.hullStrength < 1)
        {
            var maxRepairAmt = hullRepairRate * elapsedTime;
            ship.hullStrength = ship.hullStrength + maxRepairAmt;
            powerUsed = activePowerUsage * (1f - (Mathf.Clamp01(ship.hullStrength - 1f) / maxRepairAmt)) * elapsedTime;
        }

        return powerUsed;
    }
}
