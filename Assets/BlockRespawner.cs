using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRespawner : MonoBehaviour
{
    float curr=0;
    float time=1.5f;
    void Start()
    {
        FluppyManager.GetInstance.gameReset += Init;
    }

    // Update is called once per frame
    void Update()
    {
        if (FluppyManager.GetInstance.isGameOver) return;
        curr += Time.deltaTime;
        if(time <= curr)
        {
            FluppyManager.GetInstance.BlockDequeue();
            curr = 0f;
        }
    }
    private void Init()
    {
        curr = 0f;
    }
}
