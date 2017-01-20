using UnityEngine;
using UnityEngine.UI;

namespace iLogos.TankSurvival
{
	public class HealthIndicator : MonoBehaviour 
	{
		[SerializeField]
		private Image _progressImage;

		private AbstractEntity _entity;
		private Vector3 _offset;
		Quaternion _angle;

		private void Awake()
		{
			_entity = GetComponentInParent<AbstractEntity>();

			_offset = this.transform.position - _entity.transform.position;
			_angle = this.transform.rotation;
		}

		private void Update()
		{
			_progressImage.fillAmount = _entity.CurrentHealth / _entity.Health;

			this.transform.position = _entity.transform.position + _offset;
			this.transform.rotation = _angle;
		}
	}
}