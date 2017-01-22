using System;


namespace iLogos.TankSurvival
{
    public class GameOverState : AbstractGameState
    {
        public override void Prepare()
        {
            GameOverPresenter.OnRestartClickedEvent += RestartGame;
			GameOverPresenter.OnMainMenuClickedEvent += SwitchToMainMenu;
			GameOverPresenter.OnQuitClickedEvent += QuitGame;
        }

        public override void Update()
        {
            
        }

        public override void Finish()
        {
            GameOverPresenter.OnRestartClickedEvent -= RestartGame;
			GameOverPresenter.OnMainMenuClickedEvent -= SwitchToMainMenu;
			GameOverPresenter.OnQuitClickedEvent -= QuitGame;
        }

        private void RestartGame()
        {
            Game.Instance.SwitchState(new GameplayState());
        }

		private void SwitchToMainMenu ()
		{
			Game.Instance.SwitchState (new MainMenuState ());
		}

		private void QuitGame ()
		{
			Game.Instance.Quit ();
		}
    }
}
