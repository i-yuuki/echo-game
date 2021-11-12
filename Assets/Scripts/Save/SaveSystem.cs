using System;
using System.IO;
using UnityEngine;

namespace Echo.Save{
    // 仮セーブ
    [CreateAssetMenu(fileName = "Save System", menuName = "ScriptableObject/Save System")]
    public sealed class SaveSystem : ScriptableObject{

        [SerializeField] private string fileName;
        [SerializeField] private SaveData saveData;

        private string FilePath => Application.persistentDataPath + "/" + fileName;
        public SaveData SaveData => saveData;

        public void Load(){
            Debug.Log($"Loading game progress from {FilePath}");
            try{
                using(var stream = new StreamReader(FilePath)){
                    saveData = JsonUtility.FromJson<SaveData>(stream.ReadToEnd());
                }
            }catch(Exception ex){
                Debug.LogError($"Failed to load game progress! (New game?) {ex}");
            }
        }

        public void Save(){
            Debug.Log($"Saving game progress to {FilePath}");
            try{
                using(var stream = new StreamWriter(FilePath)){
                    stream.Write(JsonUtility.ToJson(saveData));
                }
            }catch(Exception ex){
                Debug.LogError($"Failed to save game progress! {ex}");
            }
        }

    }
}
