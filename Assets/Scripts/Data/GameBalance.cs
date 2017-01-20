using UnityEngine;


namespace iLogos.TankSurvival
{

    public class GameBalance : ScriptableObject
    {
        [SerializeField]
        private int _maxMonstersOnScene;


        public int MaxMonstersOnScene
        {
            get { return _maxMonstersOnScene; }
        }
    }
}