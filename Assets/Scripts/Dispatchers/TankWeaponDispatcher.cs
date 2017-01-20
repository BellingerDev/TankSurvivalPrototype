using UnityEngine;


namespace iLogos.TankSurvival
{
    public class TankWeaponDispatcher : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] _weaponToDispatch;


        private Tank _tank;


        private void Start()
        {
            _tank = GetComponent<Tank>();

            foreach (var weapon in _weaponToDispatch)
                _tank.Weapon.AddWeapon(CreateWeaponInstance(weapon));    

            _tank.Weapon.SwitchNextWeapon();       
        }

        private AbstractWeapon CreateWeaponInstance(GameObject weapon)
        {
            GameObject instance = Instantiate<GameObject>(weapon, Vector3.zero, Quaternion.identity);

            instance.transform.SetParent(this.transform);
            instance.SetActive(true);

            return instance.GetComponent<AbstractWeapon>();
        }
    }
}