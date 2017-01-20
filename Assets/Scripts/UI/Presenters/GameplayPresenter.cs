using UnityEngine;
using UnityEngine.UI;


namespace iLogos.TankSurvival
{
    public sealed class GameplayPresenter : AbstractPresenter
    {
        [SerializeField]
        private TankMoveCommand _moveCommand;

        [SerializeField]
        private TankAimingCommand _aimCommand;

        [SerializeField]
        private TankFireCommand _fireCommand;

        [SerializeField]
        private TankSwitchWeaponCommand _switchWeaponCommand;

        [SerializeField]
        private Text _destroyedEnemiesCounter;


        private void Awake()
        {
            GameProgress.OnTotalDestroyedMonstersChangedEvent += UpdateEnemiesCounter;
            _destroyedEnemiesCounter.text = Game.Instance.Progress.TotalDestroyedMonsters.ToString();
        }

        private void OnDestroy()
        {
            GameProgress.OnTotalDestroyedMonstersChangedEvent -= UpdateEnemiesCounter;
        }

        private void UpdateEnemiesCounter()
        {
            _destroyedEnemiesCounter.text = Game.Instance.Progress.TotalDestroyedMonsters.ToString();
        }

        private void Update()
        {
            Tank tank = Game.Instance.ActiveTank;

            if (_moveCommand.IsHandle())
                _moveCommand.Execute(tank);

            if (_aimCommand.IsHandle())
                _aimCommand.Execute(tank);

            if (_fireCommand.IsHandle())
                _aimCommand.Execute(tank);

            if (_switchWeaponCommand.IsHandle())
                _switchWeaponCommand.Execute(tank);
        }
    }
}