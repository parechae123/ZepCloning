using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTimer : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        FlappyManager.GetInstance.scoreText = GetComponent<Text>();
    }
}
