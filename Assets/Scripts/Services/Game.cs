using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
	public sealed class Game : SingletonMonoBehaviour<Game> 
	{
		public static event Action OnStateChangedToMainMenuEvent = delegate { };
		public static event Action OnStateChangedToGameplayEvent = delegate { };
		public static event Action OnStateChangedToGameOverEvent = delegate { };

		public static event Action OnActiveTankChangedEvent = delegate { };


		[SerializeField]
		private GameBalance _balance;

		[SerializeField]
		private string _saveName;

		private GameProgress _progress;
		private AbstractGameState _activeState;

		private TankFactory _tankFactory;
		private MonsterFactory _monsterFactory;

		private Tank _activeTank;


		protected override void Awake()
		{
			base.Awake();

			LoadProgress();

			_tankFactory = FindObjectOfType<TankFactory>();
			_monsterFactory = FindObjectOfType<MonsterFactory>();

			SwitchState(new MainMenuState());
		}

		private void Update()
		{
			if (_activeState != null)
				_activeState.Update();
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();

			SaveProgress();
		}

		public void SwitchState(AbstractGameState newState)
		{
			if(_activeState != null)
				_activeState.Finish();

			_activeState = newState;

			if (_activeState is MainMenuState)
				OnStateChangedToMainMenuEvent();

			if (_activeState is GameplayState)
				OnStateChangedToGameplayEvent();

			if (_activeState is GameOverState)
				OnStateChangedToGameOverEvent();

			_activeState.Prepare();
		}

		private void LoadProgress()
		{
			string saveString = PlayerPrefs.GetString(_saveName);
			if (String.IsNullOrEmpty(saveString))
			{
				_progress = new GameProgress();
			}
			else
			{
				_progress = JsonUtility.FromJson<GameProgress>(saveString);
			}
		}

		private void SaveProgress()
		{
			Progress.SaveVersion++;
			PlayerPrefs.SetString(_saveName, JsonUtility.ToJson(_progress));
		}

		public void ResetProgress()
		{
			_progress = new GameProgress ();
			SaveProgress ();
		}

		private void OnDrawGizmos()
		{
			Gizmos.color = Color.green;
			Gizmos.DrawWireCube(Vector3.zero, new Vector3(_balance.ArenaSize.x, 2, _balance.ArenaSize.y));
		}

		public GameBalance Balance
		{
			get { return _balance; }
		}

		public GameProgress Progress
		{
			get { return _progress; }
		}

		public TankFactory TankFactory
		{
			get { return _tankFactory; }
		}

		public MonsterFactory MonsterFactory
		{
			get { return _monsterFactory; }
		}

		public Tank ActiveTank
		{
			get { return _activeTank; }
			set
			{
				_activeTank = value;
				OnActiveTankChangedEvent();
			}
		}
	}
}
