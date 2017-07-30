using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public ShipController ship;
    public GameObject spaceStation;
    public AsteroidSpawner asteroidSpawner;

    public AudioSource buttonClickSound;

    public Image gameOverWinning;
    public Image gameOverCrewDeath;
    public Image gameOverHullBreach;

    private void Start()
    {
        ship.SpaceStationReached += Ship_SpaceStationReached;
        gameOverWinning.gameObject.SetActive(false);

        ship.CrewDied += Ship_CrewDied;
        ship.HullBreached += Ship_HullBreached;

        ResetLevel();
    }

    private void Ship_HullBreached(object sender, System.EventArgs e)
    {
        gameOverHullBreach.gameObject.SetActive(true);
    }

    private void Ship_CrewDied(object sender, System.EventArgs e)
    {
        gameOverCrewDeath.gameObject.SetActive(true);
    }

    private void Ship_SpaceStationReached(object sender, System.EventArgs e)
    {
        gameOverWinning.gameObject.SetActive(true);
    }

    public void ResetLevel()
    {
        buttonClickSound.Play();
        gameOverWinning.gameObject.SetActive(false);
        gameOverCrewDeath.gameObject.SetActive(false);
        gameOverHullBreach.gameObject.SetActive(false);

        ship.Reset();
        ship.transform.position = Vector3.zero;

        spaceStation.transform.position = Vector2.up.Rotate(Random.value * 360f) * 50f;

        asteroidSpawner.ResetAsteroids();
    }

    public void MenuButtonClicked()
    {
        buttonClickSound.Play();
        SceneManager.LoadScene(0);
    }
}
