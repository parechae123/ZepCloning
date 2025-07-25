using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSelect : InteractionUi
{
    // Start is called before the first frame update
    protected void Start()
    {
        UIManager.GetInstance.gameSelect = (RectTransform)transform;
        gameObject.SetActive(false);
    }
    public override void OnExitButton()
    {
        base.OnExitButton();
    }
    public void OnSceneChageButton()
    {
        SceneManager.LoadScene(1);
    }
}
