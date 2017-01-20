using UnityEngine;


namespace iLogos.TankSurvival
{
	public abstract class AbstractEntity : MonoBehaviour 
	{
		[SerializeField]
		protected float _health;

		[SerializeField]
		protected float _defence;

		[SerializeField]
		protected float _damage;

		[SerializeField]
		protected float _moveSpeed;

		private float _positionAccuracy = 0.1f;
		private Vector3 _velocity;


		public virtual void ObtainDamage(AbstractEntity otherEntity)
		{
			_health -= otherEntity.Damage * otherEntity.Defence;
		}

		public virtual void ObtainDamage(Bullet bullet)
		{
			_health -= bullet.Damage / Defence;
		}

		public virtual void Move(Vector3 position)
		{
			_velocity = position;
		}

		protected virtual void Update()
		{
			Vector3 newPosition = this.transform.position;

			if (Vector3.Distance(newPosition, _velocity) > _positionAccuracy)
				newPosition = Vector3.Lerp(newPosition, _velocity, Time.deltaTime * _moveSpeed);

			this.transform.position = newPosition;
		}

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

		public float MoveSpeed
		{
			get { return _moveSpeed; }
		}

		public Vector3 Velocity
		{
			get { return _velocity; }
		}
	}
}
