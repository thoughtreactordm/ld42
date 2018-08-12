using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundTimerController : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update () {
        float minutes = GameManager.instance.roundTime / 60;
        float seconds = GameManager.instance.roundTime % 60;

        if (seconds < 10) {
            text.text = Mathf.FloorToInt(minutes) + ":0" + Mathf.FloorToInt(seconds);
        } else {
            text.text = Mathf.FloorToInt(minutes) + ":" + Mathf.FloorToInt(seconds);
        }

        
	}
}
