using System;
using System.Collections.Generic;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class WeaponController : MonoBehaviour
    {        
        public event Action OnWeaponAddedEvent = delegate { };
        public event Action OnWeaponRemovedEvent = delegate { };
        public event Action OnActiveWeaponChangedEvent = delegate { };

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
            OnActiveWeaponChangedEvent();
        }

        public void SwitchNextWeapon()
        {
            int index = _availableWeapon.IndexOf(_activeWeapon);
            if (++index >= _availableWeapon.Count)
                index = 0;
            
            SwitchWeapon(_availableWeapon[index]);
        }

        public void SwitchPrevWeapon()
        {
            int index = _availableWeapon.IndexOf(_activeWeapon);
            if (--index < 0)
            {
                index = _availableWeapon.Count - 1;
            }
            
            SwitchWeapon(_availableWeapon[index]);
        }

        public void AddWeapon(AbstractWeapon weapon)
        {
            weapon.transform.SetParent(this.transform);
            weapon.Configure(_slots);

            _availableWeapon.Add(weapon);
            _activeWeapon = weapon;

            OnWeaponAddedEvent();
        }

        public void RemoveWeapon(AbstractWeapon weapon)
        {
            _availableWeapon.Remove(weapon);
            Destroy(weapon.gameObject);

            OnWeaponRemovedEvent();
        }

        public IEnumerable<AbstractWeapon> AvailableWeapon
        {
            get { return _availableWeapon; }
        }

        public int WeaponCount
        {
            get { return _availableWeapon.Count; }
        }

        public AbstractWeapon ActiveWeapon
        {
            get { return _activeWeapon; }
        }
    }
}