using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public Transform ship;
    public float beginMinDistance = 5f;
    public float spawnDistance;
    public float despawnDistance;
    public GameObject[] asteroidPrefabs;
    public int numAsteroids = 35;

    private GameObject[] spawnedAsteroids;

    private void Start()
    {
        spawnedAsteroids = new GameObject[numAsteroids];
        for (int i=0; i<spawnedAsteroids.Length; i++)
        {
            var asteroid = GameObject.Instantiate(asteroidPrefabs[Random.Range(0, asteroidPrefabs.Length)]).GetComponent<Asteroid>();
            RespawnAsteroid(asteroid.gameObject, ship, true);
            asteroid.Destroyed += Asteroid_Destroyed;
            asteroid.transform.SetParent(transform, true);
            asteroid.GetComponent<SpriteRenderer>().sortingOrder = 9;
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
                RespawnAsteroid(asteroid, ship);
            }
        }
    }

    private void RespawnAsteroid(GameObject asteroid, Transform ship, bool isBegin = false)
    {
        asteroid.transform.rotation = Quaternion.Euler(0, 0, Random.value * 360f);
        asteroid.GetComponent<Rigidbody2D>().angularVelocity = Random.value * 90f - 45f;
        asteroid.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * 1f;

        if (isBegin)
        {
            asteroid.transform.position = ship.position;
            while((asteroid.transform.position - ship.position).sqrMagnitude < beginMinDistance * beginMinDistance)
            {
                asteroid.transform.position = ship.position + (Vector3)(Random.insideUnitCircle * despawnDistance);
            }
        }
        else
        {
            var offset = (Vector2.up * spawnDistance).Rotate(Random.value * 360f);
            asteroid.transform.position = ship.position + new Vector3(offset.x, offset.y);
        }
        asteroid.SetActive(true);
    }

    public void ResetAsteroids()
    {
        foreach(var a in spawnedAsteroids)
        {
            RespawnAsteroid(a, ship, true);
        }
    }
}
