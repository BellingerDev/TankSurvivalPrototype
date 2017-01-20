using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public abstract class AbstractBullet : MonoBehaviour
    {
        public event Action OnDestroyedEvent = delegate { };

        public float Damage { get; private set; }
        public Vector3 Velocity { get; private set; }


        public void Configure(float damage, Vector3 velocity)
        {
            Damage = damage;
            Velocity = velocity;
        }

        private void Update()
        {
            this.transform.position += Velocity;
        }

        public abstract float ReceiveDamage();

        protected virtual void DestroyInstance()
        {
            OnDestroyedEvent();
            Destroy(this.gameObject);
        }
    }
}
