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

    public GameObject[] pickups;

    // Use this for initialization
    void Awake()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange) {
            fireTimer += Time.deltaTime;

            if (fireTimer >= fireRate) {
                Shoot();
            }
        }

        agent.SetDestination(target.position);
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

    private void OnDestroy()
    {
        SpawnPickups();
        GameManager.instance.kills++;
    }

    void SpawnPickups()
    {

    }
}
