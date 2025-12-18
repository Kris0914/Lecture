using UnityEditor;
using UnityEngine;

namespace P1NGMU
{
    public class GameDataManager : Singleton<GameDataManager>
    {
        public float gameTime = 0;
        public float gameScore;
        public string curld;

        public float bombTime = 2.0f;
        public float bombing = 0f;
        public bool isBomb = false;
        public float NoBombSpeed = 1.0f;

        public float fixTime = 60.0f;
        public float fixing = 0f;
        public bool isFix = false;
        public float NoFixSpeed = 1.0f;

        public float hp = 5f;
        public float maxHp = 5f;
        public int upgrade = 0;
        public int maxUpgrade = 3;

        public int bomb = 0;
        public int maxBomb = 3;

        private void Start()
        {
            
        }
        private void Update()
        {
            
        }

    }
    

}
                
