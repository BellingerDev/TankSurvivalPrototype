using UnityEngine;


namespace iLogos.TankSurvival
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
        [SerializeField]
        private GameObject _bulletPrototype;

        [SerializeField]
        private float _reloadTime;

        [SerializeField]
        private float _damage;

        private float _endReloadTime;

         
        public virtual void Shot()
        {
            if (Time.time > _endReloadTime)
            {
                ShotBulletAtLocation(_bulletPrototype, _damage);
                _endReloadTime = Time.time + _reloadTime;
            }
        }

        protected abstract void ShotBulletAtLocation(GameObject prototype, float damage);

        protected virtual AbstractBullet CreateBulletIntance(GameObject prototype)
        {
            GameObject instance = Instantiate<GameObject>(prototype, Vector3.zero, Quaternion.identity);

            instance.transform.SetParent(null);
            instance.SetActive(true);

            return instance.GetComponent<AbstractBullet>();
        }
        
        public abstract void Configure(WeaponSlot[] _slots);
    }
}