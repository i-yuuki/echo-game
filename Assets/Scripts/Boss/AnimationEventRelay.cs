using UnityEngine;

namespace Echo.Boss{
    public sealed class AnimationEventRelay : MonoBehaviour{

        public void Send(string methodName){
            transform.parent.SendMessage(methodName);
        }

    }
}
