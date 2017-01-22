using System;
using UnityEngine;
using UnityEngine.UI;


namespace iLogos.TankSurvival
{
	public class DestroyedEnemiesPresenter : AbstractPresenter
	{
		[SerializeField]
		private Text _countText;


		private void Awake()
		{
			GameProgress.OnTotalDestroyedMonstersChangedEvent += ChangeCount;
			ChangeCount ();
		}

		private void OnDestroy()
		{
			GameProgress.OnTotalDestroyedMonstersChangedEvent -= ChangeCount;
		}

		private void ChangeCount()
		{
			_countText.text = Game.Instance.Progress.TotalDestroyedMonsters.ToString();
		}
	}
}

