using System;
using System.Diagnostics;

namespace Assets.Scripts.Player.Defines
{
    class Stat
    {
        private byte atk;
        private byte currHP;
        private byte maxHP;

        private float moveSpeed;
        public float GetMoveSpeed() => moveSpeed;
        public bool IsDie() => currHP <= 0;
        public void GetDamage(byte damage)
        {
            try
            {
                checked { currHP -= damage; }
            }
            catch (OverflowException ex)
            {
                currHP = 0;
            }
            UnityEngine.Debug.Log($"데미지{damage},체력{currHP}");
        }

        public Stat(byte atk, byte currHP, byte maxHP, float moveSpeed)
        {
            this.atk = atk;
            this.currHP = currHP;
            this.maxHP = maxHP;
            this.moveSpeed = moveSpeed;
        }
    }
}
