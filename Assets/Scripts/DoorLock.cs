using System.Linq;
using UnityEngine;

namespace Echo{
    public class DoorLock : MonoBehaviour{

        private bool unlocked;
        [SerializeField] private Door door;

        [Header("Conditions")]
        [SerializeField] private GameObject[] objectsMustBeDestroyed;

        private void Start(){
            unlocked = false;
        }

        private void Update(){
            if(unlocked) return;
            if(objectsMustBeDestroyed.All(obj => !obj)){
                unlocked = true;
                door.IsLocked = false;
            }
        }

    }
}
