using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    public AudioSource music;
    public AudioSource buttonClick;

    private void Start()
    {
        music.Play();
    }

    public void NewGameButtonClicked()
    {
        buttonClick.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClicked()
    {
        buttonClick.Play();
        Application.Quit();
    }
}
