using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    public float maxPower = 100f;
    public float crewHealth = 1f;
    public float hullStrength = 1f;

    public float CurrentPower { get; private set; }
    public bool IsWorking { get; private set; }
    public bool IsExploded { get; private set; }

    private ShipComponent[] shipComponenents;
    private Rigidbody2D rb;
    private SpriteRenderer shipRenderer;
    private ParticleSystem shipExplosion;

    // Use this for initialization
    void Start()
    {
        shipComponenents = GetComponentsInChildren<ShipComponent>();
        rb = GetComponent<Rigidbody2D>();
        shipRenderer = GetComponent<SpriteRenderer>();
        shipExplosion = GetComponentsInChildren<ParticleSystem>().First(c => c.name == "ship_explosion");

        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsExploded)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            return;
        }

        float totalPowerUsage = 0f;

        foreach(var sc in shipComponenents)
        {
            totalPowerUsage += sc.ProcessForFrame(this, Time.deltaTime);
        }

        CurrentPower = Mathf.Clamp(CurrentPower - totalPowerUsage, 0, maxPower);
        if (CurrentPower <= 0)
        {
            IsWorking = false;
        }

        crewHealth = Mathf.Clamp01(crewHealth);
        if (crewHealth <= 0)
        {
            Debug.Log("everyone dead");
        }
    }

    public void Reset()
    {
        CurrentPower = maxPower;
        crewHealth = 1f;
        hullStrength = 1f;
        IsWorking = true;
        shipRenderer.enabled = true;
        IsExploded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "asteroid")
        {
            hullStrength -= Mathf.Clamp(collision.relativeVelocity.magnitude, 0, 10f) / 100f;
        }
        
        if (hullStrength <= 0 && shipRenderer.enabled)
        {
            shipRenderer.enabled = false;
            IsWorking = false;
            IsExploded = true;
            rb.velocity = Vector2.zero;
            shipExplosion.Play();
        }
    }
}
