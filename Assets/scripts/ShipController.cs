using System;
using System.Collections;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipController : MonoBehaviour
{
    public float maxPower = 100f;
    public float crewHealth = 1f;
    public float hullStrength = 1f;
    public Transform spaceStation;

    public float CurrentPower { get; private set; }
    public bool IsWorking { get; private set; }
    public bool IsExploded { get; private set; }

    public event EventHandler AsteroidCollision;
    public event EventHandler CrewDied;
    public event EventHandler HullBreached;
    public event EventHandler SpaceStationReached;

    public event EventHandler ThrusterActivationChanged;
    public event EventHandler HullRepairActivationChanged;
    public event EventHandler LifeSupportActivationChanged;
    public event EventHandler ShieldsActivationChanged;
    public event EventHandler SpaceBrakesActivationChanged;
    public AudioSource asteroidHit;

    private ShipComponent[] shipComponenents;
    private Rigidbody2D rb;
    private SpriteRenderer shipRenderer;
    private SpriteRenderer compassRenderer;
    private ParticleSystem shipExplosion;
    private AudioSource shipExplosionSound;

    // Use this for initialization
    void Start()
    {
        shipComponenents = GetComponentsInChildren<ShipComponent>();
        rb = GetComponent<Rigidbody2D>();
        shipRenderer = GetComponent<SpriteRenderer>();
        shipExplosion = GetComponentsInChildren<ParticleSystem>().First(c => c.name == "ship_explosion");
        compassRenderer = GetComponentsInChildren<SpriteRenderer>().First(sr => sr.name == "compass");

        shipExplosionSound = GetComponent<AudioSource>();
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsExploded)
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0;
            compassRenderer.enabled = false;
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
            OnCrewDeath();
        }

        UpdateCompass();
    }

    private void UpdateCompass()
    {
        var dirVec = spaceStation.transform.position - transform.position;
        var angle = Mathf.Atan2(dirVec.y, dirVec.x) * 180f / Mathf.PI;
        compassRenderer.transform.position = transform.position + dirVec.normalized * 3f;
        compassRenderer.transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
    }

    public void Reset()
    {
        CurrentPower = maxPower;
        crewHealth = 1f;
        hullStrength = 1f;
        IsWorking = true;
        shipRenderer.enabled = true;
        IsExploded = false;
        compassRenderer.enabled = true;

        foreach (var c in shipComponenents) { c.Reset(); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "asteroid")
        {
            StartCoroutine(OnAsteroidCollision(collision));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "spaceStation")
        {
            OnSpaceStationReached();
        }
    }

    private IEnumerator OnAsteroidCollision(Collision2D collision)
    {
        hullStrength -= Mathf.Clamp(collision.relativeVelocity.magnitude, 0, 10f) / 100f;
        asteroidHit.Play();
        if (hullStrength <= 0 && shipRenderer.enabled)
        {
            shipRenderer.enabled = false;
            IsWorking = false;
            IsExploded = true;
            rb.velocity = Vector2.zero;
            shipExplosionSound.Play();
            shipExplosion.Play();

            yield return new WaitForSeconds(2);

            if (HullBreached != null)
            {
                HullBreached(this, EventArgs.Empty);
            }
        }
    }

    private void OnSpaceStationReached()
    {
        IsExploded = true; // hack to make ship stop everything
        if (SpaceStationReached != null)
        {
            SpaceStationReached(this, EventArgs.Empty);
        }
    }

    private void OnCrewDeath()
    {
        IsExploded = true;
        if (CrewDied != null)
        {
            CrewDied(this, EventArgs.Empty);
        }
    }
}
