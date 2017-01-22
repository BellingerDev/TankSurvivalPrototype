using UnityEngine;


namespace iLogos.TankSurvival
{
    public class HighExplosiveCannonBullet : AbstractBullet
    {
        [SerializeField]
        private int _maxTargets;

        private int _currentTargetCount;


        public override int ReceiveDamage()
        {
			Velocity = Vector3.zero;

            if (_currentTargetCount <= _maxTargets)
                _currentTargetCount++;
            else
			{
				DestroyInstance();
				return 0;
			}

            return Damage;
        }

        public override void ResetInstance()
        {
            base.ResetInstance();

            _currentTargetCount = _maxTargets;
        }
    }
}