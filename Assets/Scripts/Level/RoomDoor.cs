using UnityEngine;

namespace Echo.Level{
    public class RoomDoor : MonoBehaviour{

        [SerializeField] private Animator animator;
        [SerializeField] private new Collider collider;

        public void Open(){
            animator.SetTrigger("Open");
            collider.enabled = false;
        }

    }
}
