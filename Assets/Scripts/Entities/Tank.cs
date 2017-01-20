using System.Collections.Generic;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class Tank : AbstractEntity
    {
        [SerializeField]
        private Transform _headTransform;

        [SerializeField]
        private WeaponSlot[] _slots;

        private List<AbstractWeapon> _availableWeapon = new List<AbstractWeapon>();
        private AbstractWeapon _activeWeapon;


        public void Fire()
        {
            if (_activeWeapon != null)
                _activeWeapon.Shot();
        }

        public void SwitchWeapon<T>() where T : AbstractWeapon
        {
            _activeWeapon = _availableWeapon.FindLast(w => w is T);
        }

        public void SwitchWeapon(AbstractWeapon weapon)
        {
            _activeWeapon = weapon;
        }

        public void AddWeapon(AbstractWeapon weapon)
        {
            weapon.transform.SetParent(this.transform);
            weapon.Configure(_slots);

            _availableWeapon.Add(weapon);
        }

        public void MoveHead(Vector3 position)
        {
            _headTransform.LookAt(position);
        }

        public IEnumerable<AbstractWeapon> AvailableWeapon
        {
            get { return _availableWeapon; }
        }
    }
}