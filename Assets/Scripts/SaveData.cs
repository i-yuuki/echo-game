using System;
using System.IO;
using UnityEngine;

namespace Echo{
    // 仮セーブ
    [Serializable]
    public sealed class SaveData{

        private static string FilePath = Application.persistentDataPath + "/beta-progress.json";

        public static SaveData Instance{ get; private set; } = new SaveData();

        public int levelsCompleted = 0;
        public int health = 4;
        public int maxHealth = 4;

        public static void Load(){
            try{
                using(var stream = new StreamReader(FilePath)){
                    Instance = JsonUtility.FromJson<SaveData>(stream.ReadToEnd());
                }
            }catch(Exception ex){
                Instance = new SaveData();
                Debug.LogError($"Failed to load game progress! {ex}");
            }
        }

        public static void Save(){
            try{
                using(var stream = new StreamWriter(FilePath)){
                    stream.Write(JsonUtility.ToJson(Instance));
                }
            }catch(Exception ex){
                Instance = new SaveData();
                Debug.LogError($"Failed to save game progress! {ex}");
            }
        }

    }
}
