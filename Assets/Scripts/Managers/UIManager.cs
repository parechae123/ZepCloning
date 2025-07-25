using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingleTon<UIManager>
{
    public Canvas mainCanvas;
    public RectTransform hairSelectUI;
    public RectTransform pressSpaceBar;
    public RectTransform gameSelect;
    public RectTransform dialogWindow;
    public delegate void Interaction();
    private Interaction Interactions;
    public Action hairSave;

    public delegate void DialogSetting(string dialogID);
    public DialogSetting dialogSetting;
    protected override void Init()
    {

    }
    public void ClearInteraction()
    {
        Interactions = null;
    }
    public void RegistInteraction(Interaction interactions)
    {
        ClearInteraction();
        Interactions += interactions;
    }
    public void SetDialog(string str)
    {
        dialogSetting(str);
    }
    public void InteractionInvoke()
    {
        Interactions?.Invoke();
    }


}
