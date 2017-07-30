using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    public float maxPower = 100f;
    public float crewHealth = 1f;
    public float hullStrength = 1f;

    public float CurrentPower { get; private set; }

    private ShipComponent[] shipComponenents;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        shipComponenents = GetComponentsInChildren<ShipComponent>();
        rb = GetComponent<Rigidbody2D>();

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        float totalPowerUsage = 0f;

        foreach(var sc in shipComponenents)
        {
            totalPowerUsage += sc.powerUsage * Time.deltaTime;
        }

        CurrentPower -= totalPowerUsage;
    }

    public void Reset()
    {
        CurrentPower = maxPower;
        crewHealth = 1f;
        hullStrength = 1f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "asteroid")
        {
            hullStrength -= Mathf.Clamp(collision.relativeVelocity.magnitude, 0, 10f) / 100f;
            if (hullStrength <= 0)
            {
                Debug.Log("game over");
            }
        }
    }
}
