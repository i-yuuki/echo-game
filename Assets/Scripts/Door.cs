using UnityEngine;

namespace Echo{
    public sealed class Door : MonoBehaviour{

        [SerializeField] private bool isLocked;

        [SerializeField] private Transform exit;
        [SerializeField] private Door partner;

        public bool IsLocked{
            get => isLocked;
            set => isLocked = value;
        }

        public void Enter(GameObject obj){
            if(IsLocked || !partner) return;
            var characterController = obj.GetComponent<CharacterController>();
            if(characterController) characterController.enabled = false;
            obj.transform.position = partner.exit.position;
            if(characterController) characterController.enabled = true;
        }

    }
}
