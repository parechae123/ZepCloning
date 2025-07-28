using DG.Tweening;
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
    public Text characterName;
    public Image charactorImage;
    [SerializeField]public DialogData dialogs;
    int currIndex;
    Coroutine coroutine;
    private void Awake()
    {
        UIManager.GetInstance.dialogSetting = null;
        UIManager.GetInstance.dialogSetting += SetDialog;
        UIManager.GetInstance.dialogWindow = (RectTransform)this.transform;
        gameObject.SetActive(false);

    }
    public void SetDialog(string dialogID)
    {
        ResourceManager.GetInstance.LoadAsync<TextAsset>("DialogData",(result) =>
        {
            DialogData tempData = JsonConvert.DeserializeObject<DialogData>(result.text);
            dialogs = tempData;
            dialogs = new DialogData();
            dialogs.sheet = tempData.sheet.Where((x) => x.dialogID == dialogID).ToArray();
            currIndex = 0;
            OnInteraction();
            UIManager.GetInstance.RegistInteraction(() => OnInteraction());
        });
    }
    public void OnInteraction()
    {
        NextDialog(currIndex);
        currIndex++;
    }
    public void NextDialog(int index)
    {
        if (index >= dialogs.sheet.Length)
        {
            UIManager.GetInstance.ClearInteraction();
            gameObject.SetActive(false);
            return;
        }
        gameObject.SetActive(true);
        DialogStruct dialog = dialogs.sheet[index];
        mainText.text = dialog.dialog;

        ResetCoroutine();
        coroutine = StartCoroutine(TextDirrecting(dialog.dialog, dialog.typedelay, index));
        characterName.text = dialog.character;

        if (dialog.imageName != "None")
        {
            ResourceManager.GetInstance.LoadAsync<Sprite>(dialog.imageName, (result) =>
            {
                charactorImage.sprite = result;
            });
        }
        else charactorImage.sprite = null;
    }
    IEnumerator TextDirrecting(string dialog ,float t,int index)
    {
        WaitForSeconds seconds = new WaitForSeconds(t);
        mainText.text = string.Empty;
        for (int i = 0; i < dialog.Length; i++)
        {
            TypeDirrection(dialog[i].ToString(), mainText.transform.position, index);
            yield return seconds;
            mainText.text = dialog.Substring(0, i + 1);
        }
    }
    void ResetCoroutine()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
            coroutine = null;
            subText.DOKill();
        }
        subText.text = "";
    }
    void TypeDirrection(string text, Vector3 pos, int index)
    {
        switch (dialogs.sheet[index].typingType )
        {
            case TypingType.Substring:
                break;
            case TypingType.PopCharGrow:
                subText.DOKill();
                float xPos = ((mainText.text.Length/2f) - (mainText.text.Count((x)=> x== ' ')*0.5f))  *mainText.fontSize +(subText.fontSize/2f);
                subText.transform.position = new Vector3(pos.x+xPos,pos.y,pos.z);
                subText.text = text;
                subText.rectTransform.localScale = Vector3.one * dialogs.sheet[index].typeStrength;
                Sequence dialogDirect = DOTween.Sequence();
                dialogDirect.Append(subText.rectTransform.DOScale(1, dialogs.sheet[index].typedelay).OnComplete((() => subText.text = "")));
                dialogDirect.SetEase(Ease.OutBounce);
                
                break;
            default:
                break;
        }
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
    public TypingType typingType;
    public float typedelay;
    public float typeStrength;
    public string dialogID;
    public int dialogIndex;
}