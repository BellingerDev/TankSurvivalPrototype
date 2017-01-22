using UnityEngine;


namespace iLogos.TankSurvival
{
    public abstract class AbstractWeapon : MonoBehaviour
    {
		[SerializeField]
		private string _id;

        [SerializeField]
        private GameObject _bulletPrototype;

        [SerializeField]
        private float _reloadTime;

        [SerializeField]
        private int _damage;

        private float _endReloadTime;

         
        public virtual void Shot()
        {
            if (Time.time > _endReloadTime)
            {
                ShotBulletAtLocation(_bulletPrototype, _damage);
                _endReloadTime = Time.time + _reloadTime;
            }
        }

        protected virtual AbstractBullet CreateBulletIntance(GameObject prototype)
        {
            GameObject instance = Instantiate<GameObject>(prototype, Vector3.zero, Quaternion.identity);

            instance.transform.SetParent(null);
            instance.SetActive(true);

            return instance.GetComponent<AbstractBullet>();
        }

		public string Id
		{
			get { return _id; }
		}
        
        public abstract void Configure(WeaponSlot[] _slots);
        protected abstract void ShotBulletAtLocation(GameObject prototype, int damage);
    }
}