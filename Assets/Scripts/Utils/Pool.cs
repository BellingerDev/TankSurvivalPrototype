﻿using System;
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

        private List<GameObject>    instances;


        protected override void Awake()
        {
            base.Awake();

			CreateInstances ();
        }

        private void CreateInstances()
        {
            instances = new List<GameObject>();

            foreach (var u in units)
            {
                for (int i = 0; i < u.count; i++)
                {
                    instances.Add(CreateInstance(u.prototype));
                }
            }
        }

        private GameObject CreateInstance(GameObject prototype)
        {
            return ResetInstance(Instantiate<GameObject>(prototype));
        }

        private GameObject ResetInstance(GameObject instance)
        {
            instance.transform.SetParent(this.transform);

            instance.transform.localPosition = Vector3.zero;
            instance.transform.localRotation = Quaternion.identity;
            instance.SetActive(false);

            return instance;
        }

        public GameObject Get(GameObject prototype)
        {
            GameObject go = instances.FindLast(i => i.name == prototype.name);
            if (go != null)
			{
				foreach (var poolable in go.GetComponents<IPoolable>())
					poolable.ResetInstance();

                return go;
			}

            return CreateInstance(prototype);
        }

		public GameObject Get(string id)
		{
			GameObject go = instances.FindLast (i => i.name == id);
			if (go != null)
				return go;

			var unit = Array.FindLast (units, u => u.prototype.name == id);
			if (unit != null)
				return CreateInstance (unit.prototype);

			return GameObject.CreatePrimitive (PrimitiveType.Cylinder);
		}

        public void Retrieve(GameObject instance)
        {
            instances.Add(ResetInstance(instance));
        }
    }
}