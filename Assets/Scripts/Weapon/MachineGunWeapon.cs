using System;
using System.Linq;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class MachineGunWeapon : AbstractWeapon
    {
        [SerializeField]
        private float _bulletSpeed;

        [SerializeField]
        private string[] _slotIds;

        private int _activeSlot;

        private WeaponSlot[] _slots;


        protected override void ShotBulletAtLocation(GameObject prototype, float damage)
        {
                        
            Vector3 bulletVelocity = _slots[_activeSlot].transform.forward * _bulletSpeed;
            Vector3 bulletPosition = _slots[_activeSlot].transform.position;
            Quaternion bulletRotation = _slots[_activeSlot].transform.localRotation;

            AbstractBullet bullet = CreateBulletIntance(prototype);

            bullet.transform.position = bulletPosition;
            bullet.transform.localRotation = bulletRotation;

            bullet.Configure(damage, bulletVelocity);

            if (++_activeSlot > _slots.Length - 1)
                _activeSlot = 0;
        }

        public override void Configure(WeaponSlot[] slots)
        {
            _slots = Array.FindAll(slots, s => _slotIds.Contains(s.Id));
        }
    }
}