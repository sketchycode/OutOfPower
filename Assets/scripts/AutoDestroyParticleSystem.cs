using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class AutoDestroyParticleSystem : MonoBehaviour
{
    private ParticleSystem effect;

    // Use this for initialization
    void Start()
    {
        effect = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!effect.IsAlive())
        {
            Destroy(gameObject);
        }
    }
}
