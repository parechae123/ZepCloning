using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Managers;

public class FluppyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    float currTime = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FluppyManager.GetInstance.gameReset += Init;
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        if (FluppyManager.GetInstance.isGameOver) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 3f,ForceMode2D.Impulse);
        }
        currTime += Time.deltaTime;
        FluppyManager.GetInstance.scoreText.text = currTime.ToString("N2");
    }
    IEnumerator StartDirrect()
    {
        for (int i = 3; i > 0 ; i--)
        {
            FluppyManager.GetInstance.startTimer.rectTransform.localScale = Vector3.one;
            FluppyManager.GetInstance.startTimer.text = i.ToString();
            FluppyManager.GetInstance.startTimer.rectTransform.DOScale(Vector3.zero,0.8f);
            yield return new WaitForSeconds(1f);
        }
        FluppyManager.GetInstance.startTimer.text = string.Empty;
        FluppyManager.GetInstance.isGameOver = false;
        rb.simulated = true;
    }
    public void Init()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        FluppyManager.GetInstance.isGameOver = true;
        currTime = 0f;
        transform.position = new Vector3(-7f, 0.5f,0);
        FluppyManager.GetInstance.scoreText.text = currTime.ToString("N2");
        StartCoroutine(StartDirrect());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FluppyManager.GetInstance.isGameOver = true;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        FluppyManager.GetInstance.gameOverPannel.SetActive(true);
    }
}
