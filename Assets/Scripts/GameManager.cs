using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int kills;
    public int wallsCreated;
    public int wallsDestroyed;
    public float roundTime;

    public bool ready;

    // Use this for initialization
    void Awake() {

        if (instance == null) {
            instance = this;
        } else if (instance != this) { 
            Destroy(gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
	}

    public void Init()
    {
        kills = 0;
        wallsCreated = 0;
        wallsDestroyed = 0;
        roundTime = 0;

        ready = true;
    }
	
	// Update is called once per frame
	void Update () {

        if (ready) {
            roundTime += Time.deltaTime;

        }

		if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
	}

    public void GameOver()
    {
        ready = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
