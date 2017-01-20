using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    [Serializable]
    public sealed class TankAimingCommand : AbstractPlayerCommand
    {
        public static event Action<Vector3> OnAimHandleEvent = delegate { };

        private Vector3 _aimPosition;


        public override bool IsHandle()
        {
            _aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            return true;
        }

        public override void Execute(Tank tank)
        {
            tank.MoveHead(_aimPosition);
        }
    }
}