using System;
using UnityEngine;
using UniRx;

namespace Echo.Audio{
    [CreateAssetMenu(fileName = "New Effect Channel", menuName = "ScriptableObject/Audio/AudioEffectChannel")]
    public sealed class AudioEffectChannel : ScriptableObject{

        private readonly Subject<bool> onSlowmoRequest = new Subject<bool>();

        public IObservable<bool> OnSlowmoRequest => onSlowmoRequest;

        public void RequestSlowmo(bool slowmo){
            onSlowmoRequest.OnNext(slowmo);
        }

    }
}
