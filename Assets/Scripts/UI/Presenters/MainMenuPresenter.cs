using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
    public sealed class MainMenuPresenter : AbstractPresenter
    {
        public static event Action OnPlayClickedEvent = delegate { };
		public static event Action OnContinueClickedEvent = delegate { };
		public static event Action OnQuitClickedEvent = delegate { };

		[SerializeField]
		private GameObject _continueButton;


		private void Awake()
		{
			_continueButton.SetActive (Game.Instance.Progress.SaveVersion != 0);
		}

        public void OnPlayClicked()
        {
            OnPlayClickedEvent();
        }

		public void OnContinueClicked()
		{
			OnContinueClickedEvent ();
		}

		public void OnQuitClicked()
		{
			OnQuitClickedEvent ();
		}
    }
}