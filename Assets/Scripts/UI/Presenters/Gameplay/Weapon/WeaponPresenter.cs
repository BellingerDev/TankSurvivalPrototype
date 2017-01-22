using System.Collections.Generic;
using UnityEngine;
using System;


namespace iLogos.TankSurvival
{
	public class WeaponPresenter : AbstractPresenter
	{
		[SerializeField]
		private GameObject _indicatorPrototype;

		[SerializeField]
		private WeaponUIData[] _associatedUIData;

		private WeaponController _targetWeapon;

		
		#region MonoBehaviour Callbacks

		private void Awake()
		{
			Game.OnActiveTankChangedEvent += ReAssignWeapon;
			ReAssignWeapon ();
		}

		private void OnDestroy()
		{
			Game.OnActiveTankChangedEvent -= ReAssignWeapon;

			if (_targetWeapon != null)
			{
				_targetWeapon.OnWeaponAddedEvent -= UpdateIndicators;
				_targetWeapon.OnWeaponRemovedEvent -= UpdateIndicators;
				_targetWeapon.OnActiveWeaponChangedEvent -= UpdateIndicators;
			}
		}

		#endregion

		private void ReAssignWeapon()
		{
			Tank tank = Game.Instance.ActiveTank;
			if (tank != null)
			{
				_targetWeapon = tank.Weapon;

				_targetWeapon.OnWeaponAddedEvent += UpdateIndicators;
				_targetWeapon.OnWeaponRemovedEvent += UpdateIndicators;
				_targetWeapon.OnActiveWeaponChangedEvent += UpdateIndicators;

				UpdateIndicators ();
			}
		}

		private WeaponUIData GetAssociatedData(string id)
		{
			return Array.FindLast (_associatedUIData, ad => ad.Id == id);
		}

		private void UpdateIndicators()
		{
			ClearPresentersRoot ();

			foreach (var weapon in _targetWeapon.AvailableWeapon)
			{
				WeaponUIData associatedData = GetAssociatedData (weapon.Id);
				if (associatedData != null)
				{
					WeaponIndicator indicator = CreatePresenterInstance(_indicatorPrototype) as WeaponIndicator;
					indicator.Configure(associatedData, _targetWeapon.ActiveWeapon == weapon);
				}
			}
		}
	}
}