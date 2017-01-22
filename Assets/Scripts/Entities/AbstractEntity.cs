using UnityEngine;


namespace iLogos.TankSurvival
{
	public abstract class AbstractEntity : MonoBehaviour, IPoolable
	{
		[SerializeField]
		protected int _health;

		[SerializeField]
		[RangeAttribute(0, 1)]
		protected float _defence;

		[SerializeField]
		protected int _damage;

		public float TotalHealth { get { return _health; } }
		public float CurrentHealth { get; private set; }

		public float TotalDamage { get { return _damage; } }
		public float TotalDefence { get { return _defence; } }


		#region MonoBehaviour Callbacks

		protected virtual void Awake()
		{

		}

		protected virtual void Update()
		{

		}

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
			CurrentHealth -= (float)otherEntity.TotalDamage * otherEntity.TotalDefence;

			if (CurrentHealth <= 0)
				DestroyInstance();
		}

		public virtual void ObtainDamage(AbstractBullet bullet)
		{
			CurrentHealth -= (float)bullet.ReceiveDamage() / _defence;

			if (CurrentHealth <= 0)
				DestroyInstance();
		}

		protected virtual void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(this.transform.position, 0.3f);
			Gizmos.DrawRay(this.transform.position, this.transform.forward);
		}

		public virtual void ResetInstance()
		{
			CurrentHealth = TotalHealth;
		}

		public virtual void DestroyInstance()
		{
			Pool.Instance.Retrieve(this.gameObject);
		}
	}
}
