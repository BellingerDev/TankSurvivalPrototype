using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    [Serializable]
    public sealed class TankFireCommand : AbstractPlayerCommand
    {
        [SerializeField]
        private KeyCode _fireKey;


        public override bool IsHandle()
        {
            return Input.GetKeyDown(_fireKey);
        }

        public override void Execute(Tank tank)
        {
            tank.Fire();
        }
    }
}