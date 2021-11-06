using UnityEngine;
using Cinemachine;
using UniRx;

namespace Echo.Level{
    public class Room : MonoBehaviour{

        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private RoomEnemies enemies;
        [SerializeField] private RoomDoor exit;

        private void Start(){
            if(enemies){
                enemies.OnAllEnemiesDied.Subscribe(_ => exit.Open()).AddTo(this);
            }else{
                exit.Open();
            }
        }

        public void Enter(){
            virtualCamera.Follow = transform;
            enemies.ActivateAll();
        }

    }
}
