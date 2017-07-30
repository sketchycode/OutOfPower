using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupport : ShipComponent
{
    public float activePowerUsage = 0.5f;

    private bool isComponentActive = true;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(controlKey))
        {
            isComponentActive = !isComponentActive;
        }

        powerUsage = isComponentActive ? activePowerUsage : 0f;
    }
}
