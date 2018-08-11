using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public int kills;
    public int wallsCreated;
    public int wallsDestroyed;

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

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
