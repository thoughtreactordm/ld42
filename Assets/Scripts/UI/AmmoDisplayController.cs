using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoDisplayController : MonoBehaviour {

    public GameObject[] missiles;

    public void SetDisplay(int ammo)
    {
        HideAll();

        for (int i = 0; i < ammo; i++) {
            missiles[i].SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var h in missiles) {
            h.SetActive(false);
        }
    }
}
