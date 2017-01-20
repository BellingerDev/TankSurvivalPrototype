using UnityEngine;


namespace iLogos.TankSurvival
{
	public sealed class GamePresenter : AbstractPresenter
	{
		[SerializeField]
		private GameObject _mainMenuPanel;

		[SerializeField]
		private GameObject _gameplayPanel;

		[SerializeField]
		private GameObject _gameOverPanel;


		private void Awake()
		{
			Game.OnStateChangedToMainMenuEvent += ShowMainMenuPanel;
			Game.OnStateChangedToGameplayEvent += ShowGameplayPanel;
			Game.OnStateChangedToGameOverEvent += ShowGameOverPanel;
		}

		private void OnDestroy()
		{
			Game.OnStateChangedToMainMenuEvent -= ShowMainMenuPanel;
			Game.OnStateChangedToGameplayEvent -= ShowGameplayPanel;
			Game.OnStateChangedToGameOverEvent -= ShowGameOverPanel;
		}

        private void ShowGameOverPanel()
        {
			ClearPresentersRoot();
			CreatePresenterInstance(_gameOverPanel);
        }

        private void ShowGameplayPanel()
        {
			ClearPresentersRoot();
			CreatePresenterInstance(_gameplayPanel);
        }

        private void ShowMainMenuPanel()
        {
			ClearPresentersRoot();
			CreatePresenterInstance(_mainMenuPanel);
        }
    }
}