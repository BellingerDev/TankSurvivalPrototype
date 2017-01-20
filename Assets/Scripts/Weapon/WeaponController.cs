using System.Collections.Generic;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class WeaponController : MonoBehaviour
    {        
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
            Debug.Log("Weapon Switched TO : " + weapon.GetType());
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
        }

        public IEnumerable<AbstractWeapon> AvailableWeapon
        {
            get { return _availableWeapon; }
        }
    }
}