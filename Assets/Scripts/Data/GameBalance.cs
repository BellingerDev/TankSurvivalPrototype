using UnityEngine;


namespace iLogos.TankSurvival
{
    [CreateAssetMenu(fileName = "SO_GameBalance_00", menuName = "Data/GameBalance", order = 1)]
    public class GameBalance : ScriptableObject
    {
        [SerializeField]
        private Vector2 _arenaSize;

        [SerializeField]
        private int _maxMonstersOnScene;


        public Vector2 ArenaSize
        {
            get { return _arenaSize; }
        }

        public int MaxMonstersOnScene
        {
            get { return _maxMonstersOnScene; }
        }
    }
}