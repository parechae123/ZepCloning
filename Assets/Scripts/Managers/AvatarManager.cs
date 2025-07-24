using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class AvatarManager : SingleTon<AvatarManager>
{
    public SpriteAtlas spriteAtlas;

    public delegate void HairChange(string spriteKey);
    public HairChange hairChange;
    public HairChange beardChange;

    protected override void Init()
    {
        ResourceManager.GetInstance.LoadAsync<SpriteAtlas>("CharacterAtlas", (result) => { spriteAtlas = result; },true);
    }
}
