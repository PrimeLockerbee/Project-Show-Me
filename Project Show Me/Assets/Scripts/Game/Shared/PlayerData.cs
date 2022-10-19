using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;

namespace Unity.FPS.Game
{
    [System.Serializable]
    public class PlayerData : MonoBehaviour
    {
        public int i_gotHitTotal;
        public int i_gotHitFront;
        public int i_gotHitBack;
        public float i_timePlayed;
        public int i_Score;

        public PlayerData(int gotHitTotal, int gothitfront, int gothitback, float timeplayed, int score)
        {
            i_gotHitTotal = gotHitTotal;
            i_gotHitFront = gothitfront;
            i_gotHitBack = gothitback;
            i_timePlayed = timeplayed;
        }

        void Start()
        {
            i_gotHitTotal = 0;
            i_gotHitFront = 0;
            i_gotHitBack = 0;
            i_timePlayed = 0;
            i_Score = 0;
        }


        void Update()
        {
            i_timePlayed += Time.deltaTime;

            Debug.Log(i_timePlayed);
        }
    }
}
