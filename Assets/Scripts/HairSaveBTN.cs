using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairSaveBTN : MonoBehaviour
{
    public void OnHairSave()
    {
        UIManager.GetInstance.hairSave?.Invoke();
    }
}
