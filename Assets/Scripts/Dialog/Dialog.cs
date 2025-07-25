using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Text mainText;
    public Text subText;
    public Text charactorName;
    public Image charactorImage;
    [SerializeField]public DialogData dialogs;
    int currIndex;
    private void Awake()
    {
        UIManager.GetInstance.dialogSetting += SetDialog;
        UIManager.GetInstance.dialogWindow = (RectTransform)this.transform;

    }
      /*  {
      "charater": "영종",
      "dialog": "나는 딸기",
      "imageName": "berryYoungJong",
      "typingtype": "PopCharGrow",
      "typedelay": "0.5",
      "typeStrength": "3"
    },*/
    public void SetDialog(string dialogID)
    {
        ResourceManager.GetInstance.LoadAsync<TextAsset>("DialogData",(result) =>
        {
            DialogData tempData = JsonConvert.DeserializeObject<DialogData>(result.text);
            dialogs = tempData;
            dialogs = new DialogData();
            dialogs.sheet = tempData.sheet.Where((x) => x.dialogID == dialogID).ToArray();
            gameObject.SetActive(true);
        });
    }
    public void OnInteraction()
    {

    }
}
public enum TypingType { Substring, PopCharGrow }
[Serializable]
public class DialogData
{
    public DialogStruct[] sheet;
}
public struct DialogStruct
{
    public string character;
    public string dialog;
    public string imageName;
    public TypingType typingtype;
    public float typedelay;
    public float typeStrength;
    public string dialogID;
    public int dialogIndex;
}