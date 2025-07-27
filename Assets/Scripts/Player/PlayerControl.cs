using Assets.Scripts.Managers;
using Assets.Scripts.Player.Defines;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class PlayerControl : MonoBehaviour
{
    Stat stat;
    IMoveHandler moveHandler;
    IKeyInput input;
    public SpriteAtlas atlas;
    [SerializeField] SPUM_SpriteList outLook;
    [SerializeField] Animator anim;


    // Start is called before the first frame update
    private void Awake()
    {
        outLook.Init();
        moveHandler = new PlayerMoveHandler(GetComponent<Rigidbody2D>());
        input = new PlayerInput(KeyCode.W,KeyCode.S,KeyCode.A,KeyCode.D,KeyCode.Space);
        stat = new Stat(10, 10, 10, 3);
        
    }

    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        if (input.GetPressMove)
        {
            Vector2 tempDir = input.GetMoveDir;
            moveHandler.OnMove(tempDir * stat.GetMoveSpeed());
            PlayAnimation(tempDir);
        }
        else
        {
            moveHandler.OnMove(Vector2.zero);
            PlayAnimation(Vector2.zero);
        }

        if (input.GetInteractKeyDown) UIManager.GetInstance.InteractionInvoke();
    }
    public void PlayAnimation(Vector2 num)
    {
        if (num == Vector2.zero) anim.SetFloat("RunState", 0f);
        else anim.SetFloat("RunState", 0.5f);

        if (num.x > 0) anim.transform.localScale = new Vector3(-1, 1, 1);
        else if (num.x < 0) anim.transform.localScale = new Vector3(1, 1, 1);
    }
}
