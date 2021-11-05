using UnityEngine;

namespace Echo.Boss{
    public class AnimationEventRelay : MonoBehaviour{

        public void Send(string methodName){
            transform.parent.SendMessage(methodName);
        }

    }
}
