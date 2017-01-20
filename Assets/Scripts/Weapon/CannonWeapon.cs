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
                Vector3 bulletRotation = _weaponSlot.transform.forward;

                AbstractBullet bullet = CreateBulletIntance(prototype);

                bullet.transform.position = bulletPosition;
                bullet.transform.forward = bulletRotation;

                bullet.Configure(damage, bulletVelocity);
            }
            else
                Debug.Log("Weapon Slot Not Found");
        }

        public override void Configure(WeaponSlot[] slots)
        {
            _weaponSlot = Array.FindLast(slots, s => s.Id == _weponSlotId);
        }
    }
}