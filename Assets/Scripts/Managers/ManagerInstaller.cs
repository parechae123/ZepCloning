using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerInstaller : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        AvatarManager.GetInstance.ReadyInstance();
        UIManager.GetInstance.ReadyInstance();
        ResourceManager.GetInstance.ReadyInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
