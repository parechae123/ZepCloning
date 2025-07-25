using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        UIManager.GetInstance.RegistInteraction(() => { UIManager.GetInstance.SetDialog("YoungJongDefault"); });
        UIManager.GetInstance.pressSpaceBar.gameObject.SetActive(true);

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (UIManager.GetInstance.dialogWindow.gameObject == null) return;
        if (!collision.CompareTag("Player")) return;

        UIManager.GetInstance.dialogWindow.gameObject.SetActive(false);
        UIManager.GetInstance.pressSpaceBar.gameObject.SetActive(false);
        UIManager.GetInstance.ClearInteraction();

    }
}
