using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWizard : MonoBehaviour {

    public GameObject bullet;
    public float bulletSpeed;
    public Transform shooter;

    Transform target;
    NavMeshAgent agent;

    bool inRange;

    public float fireRate;
    float fireTimer;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && GameManager.instance.ready) {
            fireTimer += Time.deltaTime;

            if (fireTimer >= fireRate) {
                Shoot();
            }
        }

        if (GameManager.instance.ready) {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        } else {
            agent.isStopped = true;
        }
    }

    void Shoot()
    {
        GameObject bulletObj = Instantiate(bullet, shooter.position, Quaternion.LookRotation(shooter.forward)) as GameObject;
        Rigidbody bulletRb = bulletObj.GetComponent<Rigidbody>();

        bulletRb.AddForce(shooter.transform.forward * bulletSpeed, ForceMode.Impulse);

        fireTimer = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player")) {
            inRange = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player")) {
            GameManager.instance.GameOver();
        }
    }
}
