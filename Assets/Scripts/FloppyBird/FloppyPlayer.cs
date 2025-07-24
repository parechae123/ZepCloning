using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using static System.Net.Mime.MediaTypeNames;

public class FloppyPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    [SerializeField]Text text;
    bool startedGame = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
        startedGame = false;
        StartCoroutine(StartDirrect());
    }

    // Update is called once per frame
    void Update()
    {
        if (!startedGame) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 3f,ForceMode2D.Impulse);
        }
    }
    IEnumerator StartDirrect()
    {
        for (int i = 3; i > 0 ; i--)
        {
            text.text = i.ToString();
            text.rectTransform.DOScale(Vector3.zero,0.8f);
            yield return new WaitForSeconds(1f);
            
        }
        text.text = string.Empty;
        startedGame = true;
        rb.simulated = true;
    }
}
