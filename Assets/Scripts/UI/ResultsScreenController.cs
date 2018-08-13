using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ResultsScreenController : MonoBehaviour {

    public GameObject killCount;
    public GameObject createdCount;
    public GameObject destroyedCount;
    public GameObject timeLabel;
    DOTweenAnimation tween;

    private void Start()
    {
        tween = GetComponent<DOTweenAnimation>();
    }

    public void Show()
    {
        tween.DOPlay();
        SetValues();
    }

	public void SetValues()
    {
        StartCoroutine(ValueAnimation());
        
        var minutes = Mathf.FloorToInt(GameManager.instance.roundTime / 60);
        var seconds = Mathf.CeilToInt(GameManager.instance.roundTime % 60);

        if (minutes < 1) {
            timeLabel.GetComponent<Text>().text = "YOU SURVIVED " + seconds + " SECONDS!";
        } else {
            timeLabel.GetComponent<Text>().text = "YOU SURVIVED " + minutes + " AND " + seconds + " SECONDS!";
        }
              
    }

    IEnumerator ValueAnimation() 
    {
        killCount.GetComponent<Text>().text = GameManager.instance.kills.ToString();
        createdCount.GetComponent<Text>().text = GameManager.instance.wallsCreated.ToString();
        destroyedCount.GetComponent<Text>().text = GameManager.instance.wallsDestroyed.ToString();

        yield return false;
    }

}
