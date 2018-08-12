using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaManager : MonoBehaviour {

    public GameObject[] stages;

	// Use this for initialization
	void Start () {
        int randomStage = Random.Range(0, stages.Length - 1);

        GameObject stage = (GameObject)Instantiate(stages[randomStage]);
        stage.transform.SetParent(this.transform);
	}
	
}
