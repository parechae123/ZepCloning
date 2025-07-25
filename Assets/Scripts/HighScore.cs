using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        FlappyManager.GetInstance.highScore = transform.GetComponent<Text>();
        FlappyManager.GetInstance.highScore.text = FlappyManager.GetInstance.highScoreData.score.ToString("N2");
        Destroy(this);
    }
}
