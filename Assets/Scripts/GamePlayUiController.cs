using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;

public class GamePlayUiController : MonoBehaviour {

    [SerializeField] TextMeshProUGUI scoreLabel;
	
    private void Awake()
    {
        Assert.IsNotNull(scoreLabel);
    }
	
	void Update () {
        string currentScore = string.Format( "{0,5:000.0}", GameManager.Instance.Score);
       // scoreLabel.text = GameManager.Instance.Score.ToString();
        scoreLabel.text = currentScore;
    }
}
