using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    [RequireComponent(typeof(WeaponController))]
    public class Tank : AbstractEntity
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

        private WeaponController _weapon;
        
		public float LinearVelocity { get; set; }
		public Quaternion AngularVelocity { get; set; }
        public Quaternion HeadAngularVelocity { get; set; }


        #region MonoBehaviour Callbacks

        protected override void Awake()
        {
            base.Awake();
            _weapon = GetComponent<WeaponController>();
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
            otherEntity.DestroyInstance();
        }

        public override void ObtainDamage(AbstractBullet bullet)
        {
            
        }

        public override void DestroyInstance()
        {
            this.gameObject.SetActive(false);

            OnDestroyedEvent();

            Destroy(this.gameObject);
        }

        public WeaponController Weapon
        {
            get { return _weapon; }
        }
    }
}