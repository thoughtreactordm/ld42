using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Vector3 offset;
    public Transform target;
    public float speed;

    private void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate () {

        Vector3 newPos = new Vector3(target.position.x, transform.position.y, target.position.z + offset.z);

        transform.position = Vector3.Lerp(transform.position, newPos, speed * Time.deltaTime);

	}
}
