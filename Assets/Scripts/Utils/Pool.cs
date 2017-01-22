using System;
using System.Collections.Generic;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class Pool : SingletonMonoBehaviour<Pool>
    {
        [Serializable]
        private class PoolUnit
        {
            public GameObject       prototype;
            public int              count;
        }

        [SerializeField]
        private PoolUnit[]          units;

		private List<GameObject> _instances = new List<GameObject> ();
		private PoolInstanceBuilder _builder = new PoolInstanceBuilder();


        protected override void Awake()
        {
            base.Awake();
			CreateInstances ();
        }

        private void CreateInstances()
        {
            foreach (var u in units)
            {
                for (int i = 0; i < u.count; i++)
                {
					_builder.SetPrototype (u.prototype)
							.CreateInstance()
							.ResetLocation ()
							.SetParentAndHide (this.transform);

					_instances.Add(_builder.Build());
                }
            }
        }

        public GameObject Get(GameObject prototype)
        {
			_builder.SetPrototype (prototype)
					.SetInstance (_instances.FindLast (i => i.name == prototype.name))
					.ResetLocation()
					.ResetBehaviours ();

			GameObject instance = _builder.Build ();

			if (_instances.Contains(instance))
				_instances.Remove (instance);

			return instance;
        }

        public void Retrieve(GameObject instance)
        {
			_builder.SetInstance (instance)
					.SetParentAndHide (this.transform);

			_instances.Add (_builder.Build ());
        }
    }
}