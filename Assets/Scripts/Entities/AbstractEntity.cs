using UnityEngine;


namespace iLogos.TankSurvival
{
	public abstract class AbstractEntity : MonoBehaviour 
	{
		[SerializeField]
		protected float _health;

		[SerializeField]
		[RangeAttribute(0, 1)]
		protected float _defence;

		[SerializeField]
		protected float _damage;

		public float CurrentHealth { get; private set; }


		#region MonoBehaviour Callbacks

		protected virtual void Awake()
		{
			CurrentHealth = Health;
		}

		protected abstract void Update();

		private void OnTriggerEnter(Collider col)
		{
			AbstractEntity entity = col.GetComponent<AbstractEntity>();
			if (entity != null)
				ObtainDamage(entity);

			AbstractBullet bullet = col.GetComponent<AbstractBullet>();
			if (bullet != null)
				ObtainDamage(bullet);
		}

		#endregion

		public virtual void ObtainDamage(AbstractEntity otherEntity)
		{
			CurrentHealth -= otherEntity.Damage * otherEntity.Defence;

			if (CurrentHealth <= 0)
				DestroyInstance();
		}

		public virtual void ObtainDamage(AbstractBullet bullet)
		{
			CurrentHealth -= bullet.ReceiveDamage() / Defence;

			if (CurrentHealth <= 0)
				DestroyInstance();
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.transform.position, 0.3f);
			Gizmos.DrawRay(this.transform.position, this.transform.forward);
		}

		public abstract void DestroyInstance();

		public float Health
		{
			get { return _health; }
		}

		public float Defence
		{
			get { return _defence; }
		}

		public float Damage
		{
			get { return _damage; }
		}
	}
}
