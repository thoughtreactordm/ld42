using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayController : MonoBehaviour {

    public GameObject[] hearts;

    public void SetDisplay(int health)
    {
        HideAll();

        for (int i = 0; i < health; i++) {
            hearts[i].SetActive(true);
        }
    }

    void HideAll()
    {
        foreach (var h in hearts) {
            h.SetActive(false);
        }
    }
}
