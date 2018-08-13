using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenuController : MonoBehaviour {

    FaderController fader;
    bool helpActive;
    HelpScreenController helpScreen;

    public bool pauseMenu;

    private void Start()
    {
        fader = GameObject.FindGameObjectWithTag("Fader").GetComponent<FaderController>();

        if (!pauseMenu) {
            helpScreen = GameObject.FindGameObjectWithTag("HelpScreen").GetComponent<HelpScreenController>();
        }
    }

    public void Play()
    {
        Time.timeScale = 1;
        StartCoroutine(StartGame());
    }

    public void Help()
    {
        if (!helpActive) {
            helpActive = true;
            helpScreen.Show();
        } else {
            helpActive = false;
            helpScreen.Hide();
        }
    }

    public void Resume()
    {
        GameManager.instance.Unpause();
    }

    IEnumerator StartGame()
    {
        fader.FadeOut();
        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("LEVEL");
        yield return false;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
