using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionPress : MonoBehaviour
{
    void Start()
    {
        UIManager.GetInstance.pressSpaceBar = (RectTransform)transform;
        gameObject.SetActive(false);
        Destroy(this);
    }

}
