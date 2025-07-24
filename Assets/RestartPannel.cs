using Assets.Scripts.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartPannel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FluppyManager.GetInstance.gameOverPannel = gameObject;
        gameObject.SetActive(false);
    }

    public void OnRestartBTN()
    {
        FluppyManager.GetInstance.gameReset.Invoke();
        gameObject.SetActive(false);
    }
    public void OnMainBTN()
    {
        SceneManager.LoadScene(0);
    }
}
