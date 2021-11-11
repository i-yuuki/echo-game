using UnityEngine;

namespace Echo.Level{
    public sealed class RoomDoor : MonoBehaviour{

        [SerializeField] private Animator animator;
        [SerializeField] private new Collider collider;

        public void Open(){
            if(animator){
                animator.SetTrigger("Open");
            }
            if(collider){
                collider.enabled = false;
            }
        }

    }
}
