using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class ExplosionsSpawner : MonoBehaviour
    {
        [Serializable]
        private class ExplosionData
        {
            [SerializeField]
            private AbstractBullet _bulletType;

            [SerializeField]
            private GameObject _explosionPrototype;

            public Type BulletType
            {
                get { return _bulletType.GetType(); }
            }

            public GameObject ExplosionPrototype
            {
                get { return _explosionPrototype; }
            }
        }

        [SerializeField]
        private ExplosionData[] _data;


        private void Awake()
        {
            AbstractBullet.OnDestroyedAtPositionEvent += SpawnExplosionAtPosition;
        }

        private void OnDestroy()
        {
            AbstractBullet.OnDestroyedAtPositionEvent -= SpawnExplosionAtPosition;
        }

        private void SpawnExplosionAtPosition(Vector3 pos, Type bulletType)
        {
            ExplosionData ed = Array.FindLast(_data, d => d.BulletType == bulletType);
            if (ed != null)
            {
                GameObject instance = Pool.Instance.Get(ed.ExplosionPrototype);

                instance.transform.position = pos;
                instance.transform.rotation = Quaternion.Euler(-90, 0, 0);
                instance.SetActive(true);
            }

            Debug.Log("Explosion Spawned");
        }
    }
}
