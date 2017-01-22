using System;


namespace iLogos.TankSurvival
{
    public sealed class GameOverPresenter : AbstractPresenter
    {
		public static event Action OnRestartClickedEvent = delegate { };
		public static event Action OnMainMenuClickedEvent = delegate { };
		public static event Action OnQuitClickedEvent = delegate { };


        public void OnRestartClicked()
        {
            OnRestartClickedEvent();
        }

		public void OnMainMenuClicked()
		{
			OnMainMenuClickedEvent ();
		}

		public void OnQuitClicked()
		{
			OnQuitClickedEvent ();
		}
    }
}