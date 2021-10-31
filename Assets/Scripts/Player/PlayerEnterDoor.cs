using UnityEngine;

namespace Echo.Player{
    public class PlayerEnterDoor : MonoBehaviour{

        private GameInput inputActions;
        private Door doorNearby;

        private void Awake(){
            inputActions = new GameInput();
            inputActions.Player.Interact.performed += ctx => {
                if(doorNearby){
                    doorNearby.Enter(gameObject);
                }
            };
        }

        private void OnEnable(){
            inputActions.Enable();
        }

        private void OnDisable(){
            inputActions.Disable();
        }

        private void OnTriggerEnter(Collider other){
            var door = other.GetComponent<Door>();
            if(!door) return;
            doorNearby = door;
        }

        private void OnTriggerExit(Collider other){
            if(doorNearby && other.gameObject == doorNearby.gameObject){
                doorNearby = null;
            }
        }

    }
}
