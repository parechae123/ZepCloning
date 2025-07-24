using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        UIManager.GetInstance.pressSpaceBar.gameObject.SetActive(true);
        UIManager.GetInstance.interaction += () => { UIManager.GetInstance.gameSelect.gameObject.SetActive(!UIManager.GetInstance.gameSelect.gameObject.activeSelf); };
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        UIManager.GetInstance.pressSpaceBar.gameObject.SetActive(false);
        UIManager.GetInstance.gameSelect.gameObject.SetActive(false);
    }
}
