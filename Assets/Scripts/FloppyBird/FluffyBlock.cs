using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluffyBlock : MonoBehaviour
{
    float curr = 0;
    float speed = 10;
    private void Start()
    {
        FluffyManager.GetInstance.gameReset += Init;
    }
    // Update is called once per frame
    void Update()
    {
        if (FluffyManager.GetInstance.isGameOver) return;
        transform.position += Vector3.left * (Time.deltaTime*speed* curr);
        curr += Time.deltaTime;
        if (transform.position.x <= -10)
        {
            FluffyManager.GetInstance.Enqueue(this.gameObject);
            curr = 0;
        }
    }

    void Init()
    {
        gameObject.SetActive(false);
        curr = 0;
    }
}
