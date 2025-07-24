using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Player.Defines
{
    interface IKeyInput
    {
        bool GetPressMove { get; }
        bool GetInteractKeyDown { get; }
        Vector2 GetMoveDir { get; }
    }
    public class PlayerInput : IKeyInput
    {
        KeyCode moveF;
        KeyCode moveB;
        KeyCode moveL;
        KeyCode moveR;
        KeyCode interact;

        private float MoveXDir {get{ return Input.GetKey(moveL) ? -1 : Input.GetKey(moveR) ? 1 : 0; } }
        private float MoveYDir { get { return Input.GetKey(moveB) ? -1 : Input.GetKey(moveF) ? 1 : 0; } }
        public bool GetPressMove { get { return Input.GetKey(moveB) || Input.GetKey(moveF) || Input.GetKey(moveL) || Input.GetKey(moveR); } }
        public Vector2 GetMoveDir { get { return new Vector2(MoveXDir, MoveYDir).normalized; } }
        public bool GetInteractKeyDown { get { return Input.GetKeyDown(interact); } }

        public PlayerInput(KeyCode moveF, KeyCode moveB, KeyCode moveL, KeyCode moveR, KeyCode interaction)
        {
            this.moveF = moveF;
            this.moveB = moveB;
            this.moveL = moveL;
            this.moveR = moveR;
            this.interact = interaction;
        }
    }
}
