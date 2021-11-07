using System;
using UnityEngine;
using Cinemachine;
using Cysharp.Threading.Tasks;
using UniRx;
using Echo.Player;

namespace Echo.Level{
    public class Room : MonoBehaviour{

        [SerializeField] private bool startOpen;
        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private RoomEnemies enemies;
        [SerializeField] private PlayerBase player;
        [SerializeField] private RoomDoor exit;

        public IObservable<Unit> OnComplete => enemies.OnAllEnemiesDied;

        private void Start(){
            OnComplete.Subscribe(_ => {
                foreach(var bullet in FindObjectsOfType<BulletBase>()){
                    Destroy(bullet.gameObject);
                }
                player.StopSlowmo();
                exit.Open();
            }).AddTo(this);
            if(startOpen){
                exit.Open();
            }
        }

        public void Enter(){
            virtualCamera.Follow = transform;
            enemies.ActivateAll();
        }

    }
}
