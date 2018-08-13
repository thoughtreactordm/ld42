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
    public bool paused;
    bool resultsScreen;

    public GameObject[] pickUps;

    ResultsScreenController resultsController;
    PauseScreenController pauseController;
    GameObject readyText;
    

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
        resultsScreen = false;

        resultsController = GameObject.FindGameObjectWithTag("ResultsDisplay").GetComponent<ResultsScreenController>();
        pauseController = GameObject.FindGameObjectWithTag("PauseScreen").GetComponent<PauseScreenController>();
        readyText = GameObject.FindGameObjectWithTag("ReadyUpText");

    }
	
	// Update is called once per frame
	void Update () {

        if (ready) {
            roundTime += Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && !ready && !resultsScreen) {
            ready = true;
            readyText.SetActive(false);
        }

		if (Input.GetKeyDown(KeyCode.Escape) && !readyText.activeInHierarchy) {
            if (paused)
                Unpause();
            else
                Pause();
        }
	}

    public void SpawnPickups(Vector3 pos)
    {
        int spawnChance = Random.Range(1, 10);

        if (spawnChance == 5f) {
            int pickUpChance = Random.Range(1, 10);

            if (pickUpChance <= 4) {
                Instantiate(pickUps[0], pos, Quaternion.identity);
            } else if (pickUpChance <= 6) { 
                Instantiate(pickUps[1], pos, Quaternion.identity);
            } else if (pickUpChance <=10) { 
                Instantiate(pickUps[2], pos, Quaternion.identity);
            }
        }
    }

    public void Pause()
    {
        paused = true;
        ready = false;
        Time.timeScale = 0;
        pauseController.Show();
    }

    public void Unpause()
    {
        Time.timeScale = 1;
        pauseController.Hide();
        StartCoroutine(ResumeGame());
    }

    IEnumerator ResumeGame()
    {
        yield return new WaitForSeconds(0.6f);
        paused = false;
        ready = true;
    }

    public void GameOver()
    {
        ready = false;

        resultsController.gameObject.SetActive(true);
        resultsController.Show();
        resultsScreen = true;
    }
}
