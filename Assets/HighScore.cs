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
        FluffyManager.GetInstance.highScore = transform.GetComponent<Text>();
        FluffyManager.GetInstance.highScore.text = FluffyManager.GetInstance.highScoreData.score.ToString("N2");
        Destroy(this);
    }
}
