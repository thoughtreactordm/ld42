using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerWall : MonoBehaviour { 

    public LayerMask wallMask;
    public float growthRate;
    DOTweenAnimation animation;

    float distance;
    bool growing;

    void Awake()
    {
        animation = GetComponent<DOTweenAnimation>();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 200f, (int)wallMask)) {
            distance = Vector3.Distance(transform.position, hit.point);

            animation.endValueV3 = new Vector3(0,0, distance);

            growing = true;
        }
    }

    // Update is called once per frame
    void Update () {

        if (growing) {
            animation.DOPlay();
            growing = false;
        }
	}

    public void StopGrowing()
    {
        //growing = false;
        animation.DOPause();
    }
}
