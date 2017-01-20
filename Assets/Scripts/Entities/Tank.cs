using System;
using System.Collections.Generic;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class Tank : AbstractEntity
    {
        public static event Action OnDestroyedEvent = delegate { };
        
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

        public void SwitchWeapon(AbstractWeapon weapon)
        {
            _activeWeapon = weapon;
        }

        public void SwitchNextWeapon()
        {
            int index = _availableWeapon.IndexOf(_activeWeapon);
            if (++index < _availableWeapon.Count)
                SwitchWeapon(_availableWeapon[index]);
        }

        public void SwitchPrevWeapon()
        {
            int index = _availableWeapon.IndexOf(_activeWeapon);
            if (--index >= 0)
                SwitchWeapon(_availableWeapon[index]);
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

        public override void DestroyInstance()
        {
            this.gameObject.SetActive(false);

            OnDestroyedEvent();

            Destroy(this.gameObject);
        }

        public IEnumerable<AbstractWeapon> AvailableWeapon
        {
            get { return _availableWeapon; }
        }
    }
}