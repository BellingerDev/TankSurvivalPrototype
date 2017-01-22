using UnityEngine;


namespace iLogos.TankSurvival
{
	[CreateAssetMenu(fileName = "SO_WeaponUIData_00", menuName = "Data/WeaponUIData", order = 1)]
	public class WeaponUIData : ScriptableObject
	{
		[SerializeField]
		private string _id;

		[SerializeField]
		private Sprite _icon;


		public string Id
		{
			get { return _id; }
		}

		public Sprite Icon
		{
			get { return _icon; }
		}
	}
}