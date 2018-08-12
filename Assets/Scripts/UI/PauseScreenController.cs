using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseScreenController : MonoBehaviour {

    DOTweenAnimation tween;

    private void Start()
    {
        tween = GetComponent<DOTweenAnimation>();
    }

    public void Show()
    {
        tween.DORestart();
    }

    public void Hide()
    {
        tween.DOPlayBackwards();
    }
}
