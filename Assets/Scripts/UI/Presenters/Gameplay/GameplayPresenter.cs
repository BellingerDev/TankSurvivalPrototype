using UnityEngine;
using UnityEngine.UI;


namespace iLogos.TankSurvival
{
    public sealed class GameplayPresenter : AbstractPresenter
    {
		[SerializeField]
		private GameObject _weaponPanel;

		[SerializeField]
		private GameObject _destroyedEnemiesPanel;

        [SerializeField]
        private TankMoveCommand _moveCommand;

        [SerializeField]
        private TankAimingCommand _aimCommand;

        [SerializeField]
        private TankFireCommand _fireCommand;

        [SerializeField]
        private TankSwitchWeaponCommand _switchWeaponCommand;


        private void Awake()
        {
			CreatePresenterInstance (_weaponPanel);
			CreatePresenterInstance (_destroyedEnemiesPanel);
        }

        private void OnDestroy()
        {
			
        }

        private void Update()
        {
            Tank tank = Game.Instance.ActiveTank;

            if (_moveCommand.IsHandle())
                _moveCommand.Execute(tank);

            if (_aimCommand.IsHandle())
                _aimCommand.Execute(tank);

            if (_fireCommand.IsHandle())
                _fireCommand.Execute(tank);

            if (_switchWeaponCommand.IsHandle())
                _switchWeaponCommand.Execute(tank);
        }
    }
}