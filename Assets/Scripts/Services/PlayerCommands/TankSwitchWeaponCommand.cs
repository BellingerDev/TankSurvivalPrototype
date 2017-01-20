using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    [Serializable]
    public sealed class TankSwitchWeaponCommand : AbstractPlayerCommand
    {
        private enum SwitchDirection
        {
            Left, Right, None
        }

        [SerializeField]
        private KeyCode _prevWeaponKey;

        [SerializeField]
        private KeyCode _nextWeaponKey;

        private SwitchDirection _direction;


        public override bool IsHandle()
        {
            bool isHandle = false;
            _direction = SwitchDirection.None;

            if (Input.GetKeyDown(_prevWeaponKey))
            {
                _direction = SwitchDirection.Left;
                isHandle = true;
            }
                    

            if (Input.GetKeyDown(_nextWeaponKey))
            {
                _direction = SwitchDirection.Right;
                isHandle = true;
            }
                
            return isHandle;
        }

        public override void Execute(Tank tank)
        {
            switch (_direction)
            {
                case SwitchDirection.Left:
                    tank.SwitchPrevWeapon();
                    break;

                case SwitchDirection.Right:
                    tank.SwitchNextWeapon();
                    break;
            }
        }
    }
}