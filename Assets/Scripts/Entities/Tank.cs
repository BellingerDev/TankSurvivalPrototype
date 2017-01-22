using System;
using UnityEngine;
using UnityEngine.AI;


namespace iLogos.TankSurvival
{
    [RequireComponent(typeof(WeaponController))]
    public class Tank : AbstractEntity, IPoolable
    {
        public static event Action OnDestroyedEvent = delegate { };
        
        [SerializeField]
        private Transform _headTransform;

        [SerializeField]
        private float _headRotateSpeed;
        
        [SerializeField]
		protected float _moveSpeed;

		[SerializeField]
		private float _rotateSpeed;

        
		public float LinearVelocity { get; set; }
		public Quaternion AngularVelocity { get; set; }
		public Quaternion HeadAngularVelocity { get; set; }

		public WeaponController Weapon { get; private set; }


        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
            Weapon = GetComponent<WeaponController>();
        }

        protected override void Update()
        {
            Vector3 tankPosition = this.transform.position;
            Vector3 tankForward = this.transform.forward;

            Quaternion tankRotation = this.transform.rotation;
            Quaternion tankHeadRotation = _headTransform.rotation;

            tankPosition += tankForward * LinearVelocity * _moveSpeed;
            tankRotation = Quaternion.Slerp(tankRotation, tankRotation * AngularVelocity, Time.deltaTime * _rotateSpeed);
            tankHeadRotation = Quaternion.Slerp(tankHeadRotation, HeadAngularVelocity, Time.deltaTime * _headRotateSpeed);

            this.transform.position = tankPosition;
            this.transform.rotation = tankRotation;

            _headTransform.rotation = tankHeadRotation;
        }

        #endregion

        public override void ObtainDamage(AbstractEntity otherEntity)
        {
            base.ObtainDamage(otherEntity);

            if (otherEntity is Monster)
                otherEntity.DestroyInstance();
        }

        public override void ObtainDamage(AbstractBullet bullet)
        {
            // override this for skip damage from bullets
        }

        public override void ResetInstance()
        {
            base.ResetInstance();

            LinearVelocity = 0.0f;
            AngularVelocity = Quaternion.identity;
            HeadAngularVelocity = Quaternion.identity;
        }

        public override void DestroyInstance()
        {
            base.DestroyInstance();
            OnDestroyedEvent();
        }
    }
}