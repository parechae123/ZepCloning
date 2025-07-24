using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluffyExplaneText : MonoBehaviour
{
    public void OnButtonClick()
    {
        FluffyManager.GetInstance.gameReset.Invoke();
        gameObject.SetActive(false);
        
    }
}
