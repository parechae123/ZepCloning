using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Avx;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HairUIInitialize : MonoBehaviour
{
    public Button[] beardBtnArr;
    public Button[] hairBtnArr;
    public SpriteAtlas atlas;

    void Start()
    {
        for (int i = 0; i < beardBtnArr.Length; i++)
        {
            int currArr = i+1; //closer 방지
            beardBtnArr[i].onClick.AddListener(() => { AvatarManager.GetInstance.beardChange($"FaceHair_{currArr}"); });
        }
        for (int i = 0; i < hairBtnArr.Length; i++)
        {
            int currArr = i + 1; //closer 방지
            hairBtnArr[i].onClick.AddListener(() => { AvatarManager.GetInstance.hairChange($"Hair_{currArr}"); });
        }
        gameObject.SetActive(false);
        UIManager.GetInstance.hairSelectUI = (RectTransform)transform;
        Destroy(this);
    }
    public void OnInspectorBTN()
    {
        List<Button> hairList = new List<Button>();
        List<Button> beardList = new List<Button>();
        for (int i = 0; i < transform.GetChild(1).childCount; i++)
        {
            beardList.Add(transform.GetChild(1).GetChild(i).GetComponent<Button>());
            transform.GetChild(1).GetChild(i).GetChild(0).GetComponent<Image>().sprite = atlas.GetSprite($"FaceHair_{i + 1}");
        }

        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            hairList.Add(transform.GetChild(0).GetChild(i).GetComponent<Button>());
            transform.GetChild(0).GetChild(i).GetChild(0).GetComponent<Image>().sprite = atlas.GetSprite($"Hair_{i + 1}");
        }
        hairBtnArr = hairList.ToArray();
        beardBtnArr = beardList.ToArray();
    }

}
[CanEditMultipleObjects] 
[CustomEditor(typeof(HairUIInitialize))]
public class HairUIInitializeEditor : Editor
{
    // Custom inspector code...
    public override void OnInspectorGUI()
    {
        var comp = (HairUIInitialize)target;

        Undo.RecordObject(comp, "Reset Component");

        DrawDefaultInspector();

        if (GUILayout.Button("Reset (Preserve Some Fields)"))
        {
            comp.OnInspectorBTN();
            EditorUtility.SetDirty(comp);
        }
    }
}