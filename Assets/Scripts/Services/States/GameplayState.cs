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

            AttachCameraToTank();
        }

        public override void Update()
        {
            Tank tank = Game.Instance.ActiveTank;

            Vector3 tankPos = tank.transform.position;
            Vector3 arenaSize = Game.Instance.Balance.ArenaSize;

            float levelDistance = arenaSize.magnitude;
            float tankDistance = tankPos.magnitude;

            if(tankDistance > levelDistance)
            {
                tank.LinearVelocity = -tank.LinearVelocity;
                tank.CalculateLocation();
            }
        }

        public override void Finish()
        {
            Monster.OnDestroyedEvent -= SpawnOneMoreMonster;
            Tank.OnDestroyedEvent -= SwitchStateToGameOver;

            Game.Instance.ActiveTank.DestroyInstance();
            Game.Instance.ActiveTank = null;
            
            Game.Instance.MonsterFactory.DestroyInstances();
        }

        private void AttachCameraToTank()
        {
            FollowTarget follow = Camera.main.GetComponent<FollowTarget>();
            if (follow != null)
                follow.Target = Game.Instance.ActiveTank.gameObject;
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
