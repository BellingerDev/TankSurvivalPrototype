using UnityEngine;


namespace iLogos.TankSurvival
{
	public class PoolableDelayedRetriever : MonoBehaviour, IPoolable
	{
		[SerializeField]
		private float _lifeTime = 3.0f;

		private float _timeToRetrieve;


		public void ResetInstance()
		{
			_timeToRetrieve = Time.time + _lifeTime;
		}

		public void DestroyInstance()
		{
			Pool.Instance.Retrieve(this.gameObject);
		}

		private void Update()
		{
			if (Time.time > _timeToRetrieve)
				DestroyInstance();
		}
	}
}
