﻿using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
	public sealed class Game : SingletonMonoBehaviour<Game> 
	{
		public static event Action OnStateChangedToMainMenuEvent = delegate { };
		public static event Action OnStateChangedToGameplayEvent = delegate { };
		public static event Action OnStateChangedToGameOverEvent = delegate { };


		[SerializeField]
		private GameBalance _balance;

		private GameProgress _progress;
		private AbstractGameState _activeState;

		private TankFactory _tankFactory;
		private MonsterFactory _monsterFactory;


		protected override void Awake()
		{
			base.Awake();

			_progress = new GameProgress();

			_tankFactory = FindObjectOfType<TankFactory>();
			_monsterFactory = FindObjectOfType<MonsterFactory>();

			SwitchState(new MainMenuState());
		}

		private void Update()
		{
			if (_activeState != null)
				_activeState.Update();
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
	}
}
