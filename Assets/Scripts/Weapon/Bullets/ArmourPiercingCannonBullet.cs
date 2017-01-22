using UnityEngine;


namespace iLogos.TankSurvival
{
    public class ArmourPiercingCannonBullet : AbstractBullet
    {
        [SerializeField]
        private int _piercing;

        private int _currentPiercing;


        public override float ReceiveDamage()
        {
            if (--_currentPiercing <= 0)
                DestroyInstance();

            return Damage;
        }

        public override void ResetInstance()
        {
            base.ResetInstance();

            _currentPiercing = _piercing;
        }

        public int Piercing
        {
            get { return _piercing; }
        }
    }
}