using UnityEngine;


namespace iLogos.TankSurvival
{
    public class TankWeaponDispatcher : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _weaponToDispatch;


        private Tank _tank;


        private void Awake()
        {
            _tank = GetComponent<Tank>();

            foreach (var weapon in _weaponToDispatch)
                _tank.AddWeapon(weapon.GetComponent<AbstractWeapon>());

            
        }
    }
}