using UnityEngine;

namespace Echo.Level{
    public sealed class RoomDoor : MonoBehaviour{

        [SerializeField] private Animator animator;
        [SerializeField] private new Collider collider;

        public void Open(){
            animator.SetTrigger("Open");
            collider.enabled = false;
        }

    }
}
