using System;


namespace iLogos.TankSurvival
{
    public class GameOverState : AbstractGameState
    {
        public override void Prepare()
        {
            GameOverPresenter.OnRestartClickedEvent += SwitchStateToGameplay;
        }

        public override void Update()
        {
            
        }

        public override void Finish()
        {
            GameOverPresenter.OnRestartClickedEvent -= SwitchStateToGameplay;
        }

        private void SwitchStateToGameplay()
        {
            Game.Instance.SwitchState(new GameplayState());
        }
    }
}
