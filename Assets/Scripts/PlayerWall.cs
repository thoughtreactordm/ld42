using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWall : MonoBehaviour {

    public LayerMask wallMask;
    public float growthRate;

    float distance;
    bool growing;

    void Awake()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200f, (int)wallMask)) {
            distance = Vector3.Distance(transform.position, hit.point);
            growing = true;
        }
    }

    // Update is called once per frame
    void Update () {
		
        if (growing && transform.localScale.z == distance) {
            growing = false;
        }

        if (growing) {
            Vector3 newScale = new Vector3(transform.localScale.x, transform.localScale.y, distance);
            transform.localScale = Vector3.Lerp(transform.localScale, newScale, Time.deltaTime * growthRate);
        }
	}
}
