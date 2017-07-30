using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenController : MonoBehaviour
{
    private void Start()
    {
        var audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void NewGameButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}
