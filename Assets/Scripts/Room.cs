using System.Linq;
using UnityEngine;
using Cinemachine;

namespace Echo.Level{
    public class Room : MonoBehaviour{

        [SerializeField] private CinemachineVirtualCamera virtualCamera;
        [SerializeField] private GameObject[] enemies;
        [SerializeField] private RoomDoor exit;

        private bool isExitOpened;

        private void Start(){
            isExitOpened = false;
        }

        private void Update(){
            if(isExitOpened) return;
            if(enemies.All(obj => !obj)){
                isExitOpened = true;
                exit.Open();
            }
        }

        public void Enter(){
            virtualCamera.Follow = transform;
            foreach(var obj in enemies){
                if(obj){
                    obj.SetActive(true);
                }
            }
        }

    }
}
