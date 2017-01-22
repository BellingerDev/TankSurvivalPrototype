using UnityEngine;
using UnityEngine.UI;


namespace iLogos.TankSurvival
{
	public class HealthPresenter : AbstractPresenter
	{
		[SerializeField]
		private Image _progressImage;

		private AbstractEntity _entity;
		private Vector3 _offset;
		private Quaternion _angle;


		private void Awake()
		{
			_entity = GetComponentInParent<AbstractEntity>();

			_offset = this.transform.position - _entity.transform.position;
			_angle = this.transform.rotation;
		}

		private void Update()
		{
			_progressImage.fillAmount = (float)_entity.CurrentHealth / (float)_entity.TotalHealth;

			this.transform.position = _entity.transform.position + _offset;
			this.transform.rotation = _angle;
		}
	}
}