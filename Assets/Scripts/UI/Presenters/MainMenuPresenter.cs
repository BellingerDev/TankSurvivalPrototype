using System;


namespace iLogos.TankSurvival
{
    public sealed class MainMenuPresenter : AbstractPresenter
    {
        public static event Action OnPlayClickedEvent = delegate { };


        public void OnPlayClicked()
        {
            OnPlayClickedEvent();
        }
    }
}