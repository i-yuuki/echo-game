using UnityEngine;

namespace Echo.Level{
    public class RoomDoor : MonoBehaviour{

        [SerializeField] private Animator animator;

        public void Open(){
            animator.SetTrigger("Open");
        }

    }
}
