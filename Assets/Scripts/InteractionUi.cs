using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionUi : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }
    public virtual void OnExitButton()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}
