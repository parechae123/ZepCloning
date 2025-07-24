using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Assets.Scripts.Managers;

public class FluffyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        FluffyManager.GetInstance.gameReset += Init;
        rb.simulated = false;
        rb.velocity = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if (FluffyManager.GetInstance.isGameOver) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 3f,ForceMode2D.Impulse);
        }
        FluffyManager.GetInstance.UpdateTextBoard();
    }
    IEnumerator StartDirrect()
    {
        for (int i = 3; i > 0 ; i--)
        {
            FluffyManager.GetInstance.startTimer.rectTransform.localScale = Vector3.one;
            FluffyManager.GetInstance.startTimer.text = i.ToString();
            FluffyManager.GetInstance.startTimer.rectTransform.DOScale(Vector3.zero,0.8f);
            yield return new WaitForSeconds(1f);
        }
        FluffyManager.GetInstance.startTimer.text = string.Empty;
        FluffyManager.GetInstance.isGameOver = false;
        rb.simulated = true;
    }
    public void Init()
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        FluffyManager.GetInstance.isGameOver = true;
        transform.position = new Vector3(-7f, 0.5f,0);
        StartCoroutine(StartDirrect());
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FluffyManager.GetInstance.isGameOver = true;
        FluffyManager.GetInstance.CompareScore();
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        FluffyManager.GetInstance.gameOverPannel.SetActive(true);
    }
}
