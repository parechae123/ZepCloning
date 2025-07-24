using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSelect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        UIManager.GetInstance.gameSelect = (RectTransform)transform;
        gameObject.SetActive(false);
    }
    public void OnExitButton()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
    
}
