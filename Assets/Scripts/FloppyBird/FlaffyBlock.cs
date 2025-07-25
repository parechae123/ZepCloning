using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaffyBlock : MonoBehaviour
{
    float curr = 0;
    float speed = 10;
    private void Start()
    {
        FlappyManager.GetInstance.gameReset += Init;
    }
    // Update is called once per frame
    void Update()
    {
        if (FlappyManager.GetInstance.isGameOver) return;
        transform.position += Vector3.left * (Time.deltaTime*speed* curr);
        curr += Time.deltaTime;
        if (transform.position.x <= -10)
        {
            FlappyManager.GetInstance.Enqueue(this.gameObject);
            curr = 0;
        }
    }

    void Init()
    {
        gameObject.SetActive(false);
        curr = 0;
    }
    private void OnEnable()
    {
        float sizeY = Random.Range(0.5f, 2f);
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).localScale = new Vector3(1f, 20f-sizeY, 1f);
        }
    }
}

