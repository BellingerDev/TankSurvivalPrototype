using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    [Serializable]
    public sealed class TankAimingCommand : AbstractPlayerCommand
    {
        public static event Action<Vector3> OnAimHandleEvent = delegate { };

		[SerializeField]
		private bool _isEnabled;

        private Vector3 _aimPosition;


        public override bool IsHandle()
        {
            Vector3 pos = Input.mousePosition;
            pos.z = Camera.main.nearClipPlane;

            Vector3 worldPos = Camera.main.ScreenToWorldPoint(pos);

            worldPos.y = 0;

            _aimPosition = worldPos;

            return true;
        }

        public override void Execute(Tank tank)
        {
			if (_isEnabled)
            	tank.HeadAngularVelocity = Quaternion.LookRotation(_aimPosition);
        }
    }
}