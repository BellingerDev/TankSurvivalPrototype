using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public class CannonWeapon : AbstractWeapon
    {
        [SerializeField]
        private string _weponSlotId;

        [SerializeField]
        private float _bulletSpeed;

        private WeaponSlot _weaponSlot;


        protected override void ShotBulletAtLocation(GameObject prototype, float damage)
        {
            if (_weaponSlot != null)
            {
                Vector3 bulletVelocity = _weaponSlot.transform.forward * _bulletSpeed;
                Vector3 bulletPosition = _weaponSlot.transform.position;
                Quaternion bulletRotation = _weaponSlot.transform.localRotation;

                AbstractBullet bullet = CreateBulletIntance(prototype);

                bullet.transform.position = bulletPosition;
                bullet.transform.localRotation = bulletRotation;

                bullet.Configure(damage, bulletVelocity);
            }
        }

        public override void Configure(WeaponSlot[] slots)
        {
            _weaponSlot = Array.FindLast(slots, s => s.Id == _weponSlotId);
        }
    }
}