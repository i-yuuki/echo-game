using UnityEngine;

namespace Echo.Level{
    public sealed class WarpTrigger : MonoBehaviour{

        [SerializeField] private Transform exit;

        private void OnTriggerEnter(Collider other){
            if(!other.CompareTag("Player")) return;
            var characterController = other.GetComponent<CharacterController>();
            if(characterController) characterController.enabled = false;
            other.transform.position = exit.position;
            if(characterController) characterController.enabled = true;
        }

    }
}
