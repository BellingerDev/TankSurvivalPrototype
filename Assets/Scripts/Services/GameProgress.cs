using System;
using UnityEngine;


namespace iLogos.TankSurvival
{
	[Serializable]
	public sealed class GameProgress 
	{
		public static event Action OnTotalDestroyedMonstersChangedEvent = delegate { };

		[SerializeField]
		private int _totalDestroyedMonsters;

		[SerializeField]
		private int _saveVersion = 0;


		public int TotalDestroyedMonsters
		{
			get { return _totalDestroyedMonsters; }
			set
			{
				_totalDestroyedMonsters = value;
				OnTotalDestroyedMonstersChangedEvent();
			}
		}

		public int SaveVersion
		{
			get { return _saveVersion; }
			set 
			{
				_saveVersion = value;
			}
		}
	}
}
