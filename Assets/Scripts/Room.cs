using UnityEngine;
using Cinemachine;

namespace Echo{
    public class Room : MonoBehaviour{

        [SerializeField] private CinemachineVirtualCamera virtualCamera;

        private void OnTriggerEnter(Collider other){
            if(!other.CompareTag("Player")) return;
            virtualCamera.Follow = transform;
        }

    }
}
