using System;


namespace iLogos.TankSurvival
{
    public sealed class GameOverPresenter : AbstractPresenter
    {
        public static event Action OnRestartClickedEvent = delegate { };

        public void OnRestartClicked()
        {
            OnRestartClickedEvent();
        }
    }
}