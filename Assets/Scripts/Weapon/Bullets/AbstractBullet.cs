using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public abstract class AbstractBullet : MonoBehaviour, IPoolable
    {
        public static event Action<Vector3, Type> OnDestroyedAtPositionEvent = delegate { };

        public int Damage { get; private set; }
		public Vector3 Velocity { get; protected set; }


        public void Configure(int damage, Vector3 velocity)
        {
            Damage = damage;
            Velocity = velocity;
        }

        private void Update()
        {
            this.transform.position += Velocity;
        }

        public virtual void ResetInstance()
        {
            Damage = 0;
            Velocity = Vector3.zero;
        }

        public virtual void DestroyInstance()
        {
            OnDestroyedAtPositionEvent(this.transform.position, this.GetType());
            Pool.Instance.Retrieve(this.gameObject);
        }

		public abstract int ReceiveDamage();
    }
}
