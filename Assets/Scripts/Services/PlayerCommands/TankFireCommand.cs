using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    [Serializable]
    public sealed class TankFireCommand : AbstractPlayerCommand
    {
        [SerializeField]
        private KeyCode _fireKey;

        private bool _isFire = false;


        public override bool IsHandle()
        {
            if (Input.GetKeyDown(_fireKey))
                _isFire = true;

            if (Input.GetKeyUp(_fireKey))
                _isFire = false;
            
            return _isFire;
        }

        public override void Execute(Tank tank)
        {
            tank.Weapon.Fire();
        }
    }
}