using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Managers;

public class FlappyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        FlappyManager.GetInstance.gameReset += Init;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlappyManager.GetInstance.isGameOver) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 3f,ForceMode2D.Impulse);
        }
        FlappyManager.GetInstance.UpdateTextBoard();
    }
    IEnumerator StartDirrect()
    {
        for (int i = 3; i > 0 ; i--)
        {
            FlappyManager.GetInstance.startTimer.rectTransform.localScale = Vector3.one;
            FlappyManager.GetInstance.startTimer.text = i.ToString();
            FlappyManager.GetInstance.startTimer.rectTransform.DOScale(Vector3.zero,0.8f);
            yield return new WaitForSeconds(1f);
        }
        FlappyManager.GetInstance.startTimer.text = string.Empty;
        FlappyManager.GetInstance.isGameOver = false;
        rb.simulated = true;
    }
    public void Init()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        FlappyManager.GetInstance.isGameOver = true;
        transform.position = new Vector3(-7f, 0.5f,0);
        StartCoroutine(StartDirrect());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FlappyManager.GetInstance.isGameOver = true;
        FlappyManager.GetInstance.CompareScore();
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        FlappyManager.GetInstance.gameOverPannel.SetActive(true);
    }
}
