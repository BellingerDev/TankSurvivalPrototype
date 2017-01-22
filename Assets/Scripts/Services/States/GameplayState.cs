using UnityEngine;


namespace iLogos.TankSurvival
{
    public class GameplayState : AbstractGameState
    {
        public override void Prepare()
		{
			Game.Instance.TankFactory.ClearFactory ();
			Game.Instance.MonsterFactory.ClearFactory ();

            Monster.OnDestroyedEvent += SpawnOneMoreMonster;
            Tank.OnDestroyedEvent += SwitchStateToGameOver;

            Tank tank = Game.Instance.TankFactory.SpawnTankAtPosition(Vector3.zero);
            Game.Instance.ActiveTank = tank;

			Game.Instance.MonsterFactory.SpawnLevelMonsters();
        }

        public override void Update()
        {
            
        }

        public override void Finish()
        {
            Monster.OnDestroyedEvent -= SpawnOneMoreMonster;
            Tank.OnDestroyedEvent -= SwitchStateToGameOver;

            Game.Instance.ActiveTank.DestroyInstance();
            Game.Instance.ActiveTank = null;
            
            Game.Instance.MonsterFactory.DestroyInstances();
        }

        private void SwitchStateToGameOver()
        {
            Game.Instance.SwitchState(new GameOverState());
        }

        private void SpawnOneMoreMonster()
        {
			Game.Instance.Progress.TotalDestroyedMonsters++;
            Game.Instance.MonsterFactory.SpawnMonsterAtRandomPosition();
        }
    }
}
