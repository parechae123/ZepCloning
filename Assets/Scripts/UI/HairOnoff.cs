using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairOnOff : MonoBehaviour
{
    public void OnClick()
    {
        UIManager.GetInstance.hairSelectUI.gameObject.SetActive(!UIManager.GetInstance.hairSelectUI.gameObject.activeSelf);
    }
}
