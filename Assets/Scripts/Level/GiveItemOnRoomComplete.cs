using System;
using UnityEngine;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UniRx;
using Echo.Input;
using Echo.Player;
using Echo.UI.Item;

namespace Echo.Level{
    public sealed class GiveItemOnRoomComplete : MonoBehaviour{

        [SerializeField] private InputReader inputReader;
        [SerializeField] private float delay;
        [SerializeField] private Room room;
        [SerializeField] private PlayerBase player;
        [SerializeField] private ItemSelectScreen itemSelect;

        private void Start(){
            room.OnComplete.Subscribe(_ => Display().Forget()).AddTo(this);
        }

        private async UniTaskVoid Display(){
            inputReader.EnableMenuInput();
            await UniTask.Delay(TimeSpan.FromSeconds(delay));
            var itemInfo = await itemSelect.Open();
            player.ApplyItemEffect(itemInfo);
            inputReader.EnableGameplayInput();
        }

    }
}
