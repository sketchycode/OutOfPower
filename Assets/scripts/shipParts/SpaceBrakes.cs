using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceBrakes : ShipComponent
{
    public float dampeningFactor = 0.1f;
    public float activePowerUsage = 0.1f;

    private Rigidbody2D shipBody;
    private bool isComponentActive = false;

    // Use this for initialization
    void Start()
    {
        shipBody = GameObject.Find("ship").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(controlKey))
        {
            isComponentActive = !isComponentActive;
        }

        powerUsage = isComponentActive ? activePowerUsage : 0f;
        if(isComponentActive)
        {
            shipBody.velocity = (1f - (dampeningFactor * Time.deltaTime)) * shipBody.velocity;
            shipBody.angularVelocity = (1f - (dampeningFactor * Time.deltaTime)) * shipBody.angularVelocity;
        }
    }
}
