using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : ShipComponent
{
    public SpriteRenderer shieldsSprite;
    public float activePowerUsage = 0.5f;

    public AudioSource shieldsActivatingSound;
    public AudioSource shieldsDeactivatingSound;

    private void Start()
    {
        IsActivated = false;
    }

    public override float ProcessForFrame(ShipController ship, float elapsedTime)
    {
        if (!ship.IsWorking) { IsActivated = false; }
        else if (Input.GetKeyDown(controlKey)) { IsActivated = !IsActivated; }

        shieldsSprite.enabled = IsActivated;

        return (IsActivated ? activePowerUsage : 0f) * elapsedTime;
    }

    protected override void OnIsActivatedChanged(bool newValue)
    {
        if (IsActivated) { shieldsActivatingSound.Play(); }
        else { shieldsDeactivatingSound.Play(); }
    }
}
