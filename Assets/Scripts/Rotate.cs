using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

	public float degreesPerSecond = 90f;
	
	// Update is called once per frame
	void Update () {

		transform.RotateAround (transform.position, Vector3.up, Time.deltaTime * degreesPerSecond);

	}
}
