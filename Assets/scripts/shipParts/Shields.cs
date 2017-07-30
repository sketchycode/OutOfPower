using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : ShipComponent
{
    public SpriteRenderer shieldsSprite;
    private bool isComponentActive = false;
    public float activePowerUsage = 0.5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(controlKey))
        {
            isComponentActive = !isComponentActive;
        }
        powerUsage = isComponentActive ? activePowerUsage : 0f;
        shieldsSprite.enabled = isComponentActive;
    }
}
