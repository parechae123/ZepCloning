using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlaffyExplaneText : MonoBehaviour
{
    public void OnButtonClick()
    {

        FlappyManager.GetInstance.gameReset.Invoke();
        gameObject.SetActive(false);
        
    }
}
