using System;
using UnityEngine;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UniRx;
using Echo.Input;
using Echo.Player;
using Echo.Save;
using Echo.UI.Item;

namespace Echo.Level{
    public sealed class UpdateSaveOnRoomComplete : MonoBehaviour{

        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private bool setMaxHealth;
        [SerializeField] private int maxHealth;
        [SerializeField] private int levelNumber;
        [SerializeField] private PlayerBase player;
        [SerializeField] private Room room;

        private void Start(){
            room.OnComplete.Subscribe(_ => {
                saveSystem.SaveData.health = player.Health;
                if(setMaxHealth){
                    saveSystem.SaveData.maxHealth = Mathf.Max(saveSystem.SaveData.maxHealth, maxHealth);
                }
                saveSystem.SaveData.levelsCompleted = Mathf.Max(saveSystem.SaveData.levelsCompleted, levelNumber);
                saveSystem.Save();
            }).AddTo(this);
        }

    }
}
