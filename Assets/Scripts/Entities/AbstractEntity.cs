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


		#region MonoBehaviour Callbacks

		protected abstract void Awake();
		protected abstract void Update();

		#endregion

		public virtual void ObtainDamage(AbstractEntity otherEntity)
		{
			_health -= otherEntity.Damage * otherEntity.Defence;
		}

		public virtual void ObtainDamage(AbstractBullet bullet)
		{
			_health -= bullet.ReceiveDamage() / Defence;
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
