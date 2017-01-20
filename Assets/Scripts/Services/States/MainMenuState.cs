namespace iLogos.TankSurvival
{
    public class MainMenuState : AbstractGameState
    {
        public override void Prepare()
        {
            MainMenuPresenter.OnPlayClickedEvent += SwitchStateToGameplay;
        }

        public override void Update()
        {
            
        }

        public override void Finish()
        {
            MainMenuPresenter.OnPlayClickedEvent -= SwitchStateToGameplay;
        }

        private void SwitchStateToGameplay()
        {
            Game.Instance.SwitchState(new GameplayState());
        }
    }
}
