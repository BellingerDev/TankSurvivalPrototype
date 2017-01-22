using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
	public class PoolInstanceBuilder
	{
		private GameObject _prototype;
		private GameObject _instance;


		public PoolInstanceBuilder SetPrototype(GameObject prototype)
		{
			_prototype = prototype;

			return this;
		}

		public PoolInstanceBuilder SetInstance(GameObject instance)
		{
			_instance = instance;

			if (_instance == null)
				CreateInstance ();

			return this;
		}

		public PoolInstanceBuilder CreateInstance()
		{
			_instance = GameObject.Instantiate<GameObject> (_prototype, Vector3.zero, Quaternion.identity);

			return this;
		}

		public PoolInstanceBuilder ResetLocation()
		{
			Transform transform = _instance.transform;

			transform.localPosition = Vector3.zero;
			transform.localRotation = Quaternion.identity;

			return this;
		}

		public PoolInstanceBuilder SetParentAndHide(Transform parent)
		{
			_instance.transform.SetParent (parent);
			_instance.SetActive (false);

			return this;
		}

		public PoolInstanceBuilder ResetBehaviours()
		{
			IPoolable[] behaviours = _instance.GetComponents<IPoolable> ();

			foreach (IPoolable behaviour in behaviours)
				behaviour.ResetInstance ();

			return this;
		}

		public GameObject Build()
		{
			GameObject instance = _instance;
			_instance = null;

			return instance;
		}
	}
}

