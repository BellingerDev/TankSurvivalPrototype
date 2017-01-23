using UnityEngine;


namespace iLogos.TankSurvival
{
    public class ArenaSizeDrawer : MonoBehaviour
    {
        [SerializeField]
        private int _resolution;

        private LineRenderer _line;


        private void Awake()
        {
            _line = GetComponent<LineRenderer>();
        }

        private void Start()
        {
            CalculateArenaCircle(Game.Instance.Balance.ArenaSize);
        }

        public void CalculateArenaCircle(Vector2 size)
        {
            float x, y, z = 0.0f;
            float angle = 20.0f;

            _line.numPositions = (_resolution + 1);

            for (int i = 0; i < _resolution + 1; i++)
            {
                x = Mathf.Sin(Mathf.Deg2Rad * angle) * size.magnitude;
                y = Mathf.Cos(Mathf.Deg2Rad * angle) * size.magnitude;

                _line.SetPosition(i, new Vector3(x, z, y));

                angle += (360f / _resolution);
            }
        }
    }
}
