using UnityEngine;

namespace Echo.Level{
    public sealed class EnterRoomTrigger : MonoBehaviour{

        [SerializeField] private Room room;

        private void OnTriggerEnter(Collider other){
            if(!other.CompareTag("Player")) return;
            room.Enter();
        }

    }
}
