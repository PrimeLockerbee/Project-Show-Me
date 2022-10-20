using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Unity.FPS.Game;

    public class SaveSystem : MonoBehaviour
    {
        protected int gotHitTotal;
        protected int gotHitFront;
        protected int gotHitBack;
        protected float timePlayed;
        protected int score;

        public void SaveFile()
        {
            string destination = Application.persistentDataPath + "/save.dat";
            FileStream file;

            if (File.Exists(destination)) file = File.OpenWrite(destination);
            else file = File.Create(destination);

            PlayerData data = new PlayerData(gotHitTotal ,gotHitFront, gotHitBack, timePlayed, score);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Close();
        }
    }

