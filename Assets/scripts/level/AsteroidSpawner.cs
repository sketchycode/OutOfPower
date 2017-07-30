using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform ship;
    public float spawnDistance;
    public float despawnDistance;
    public GameObject[] asteroidPrefabs;

    private GameObject[] spawnedAsteroids = new GameObject[50];

    private void Start()
    {
        for(int i=0; i<spawnedAsteroids.Length; i++)
        {
            var asteroid = GameObject.Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)]).GetComponent<Asteroid>();
            asteroid.transform.position = Random.insideUnitCircle * despawnDistance;
            asteroid.transform.rotation = Quaternion.Euler(0, 0, Random.value * 360f);
            asteroid.GetComponent<Rigidbody2D>().angularVelocity = Random.value * 90f - 45f;
            asteroid.Destroyed += Asteroid_Destroyed;
            spawnedAsteroids[i] = asteroid.gameObject;
        }

    }

    private void Asteroid_Destroyed(object sender, System.EventArgs e)
    {
        var asteroid = sender as Asteroid;
        asteroid.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<spawnedAsteroids.Length; i++)
        {
            var asteroid = spawnedAsteroids[i];
            if(asteroid.activeInHierarchy == false || (asteroid.transform.position - ship.position).sqrMagnitude > despawnDistance * despawnDistance)
            {
                var offset = (Vector2.up * spawnDistance).Rotate(Random.value * 360f);
                asteroid.transform.position = ship.position + new Vector3(offset.x, offset.y);
                asteroid.SetActive(true);
            }
        }
    }
}
