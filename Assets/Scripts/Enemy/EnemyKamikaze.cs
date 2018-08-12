using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyKamikaze : MonoBehaviour {

    Transform target;
    NavMeshAgent agent;

	// Use this for initialization
	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.ready) {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        } else {
            agent.isStopped = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) {
            GameManager.instance.GameOver();
        }
    }
}
