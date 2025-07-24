using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingleTon<UIManager>
{
    public Canvas mainCanvas;
    public RectTransform hairSelectUI;
    public RectTransform pressSpaceBar;
    public RectTransform gameSelect;
    public Action interaction;
    protected override void Init()
    {

    }


}
