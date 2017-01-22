using UnityEngine;


namespace iLogos.TankSurvival
{
    public class MainMenuState : AbstractGameState
    {
        public override void Prepare()
        {
            MainMenuPresenter.OnPlayClickedEvent += StartNewGame;
			MainMenuPresenter.OnContinueClickedEvent += ContinueGame;
			MainMenuPresenter.OnQuitClickedEvent += QuitGame;
        }

        public override void Update()
        {
            
        }

        public override void Finish()
        {
			MainMenuPresenter.OnPlayClickedEvent -= StartNewGame;
			MainMenuPresenter.OnContinueClickedEvent -= ContinueGame;
			MainMenuPresenter.OnQuitClickedEvent -= QuitGame;
        }

		private void StartNewGame ()
		{
			Game.Instance.ResetProgress ();
			Game.Instance.SwitchState(new GameplayState());
		}

		private void ContinueGame ()
		{
			Game.Instance.SwitchState(new GameplayState());
		}

		private void QuitGame ()
		{
			Game.Instance.Quit ();
		}
    }
}
