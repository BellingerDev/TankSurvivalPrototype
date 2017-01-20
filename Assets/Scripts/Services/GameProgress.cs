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


		public int TotalDestroyedMonsters
		{
			get { return _totalDestroyedMonsters; }
			set
			{
				_totalDestroyedMonsters = value;
				OnTotalDestroyedMonstersChangedEvent();
			}
		}
	}
}
