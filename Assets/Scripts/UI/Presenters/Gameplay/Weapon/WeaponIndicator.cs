using UnityEngine;
using UnityEngine.UI;


namespace iLogos.TankSurvival
{
	public class WeaponIndicator : AbstractPresenter
	{
		[SerializeField]
		private Image _icon;

		[SerializeField]
		private Image _selection;


		public void Configure(WeaponUIData data, bool isActive)
		{
			_icon.sprite = data.Icon;
			_selection.gameObject.SetActive (isActive);
		}
	}
}