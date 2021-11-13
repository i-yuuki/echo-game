using UnityEngine;
using DG.Tweening;
using UniRx;

namespace Echo.Audio{
    public sealed class AudioEffectReceiver : MonoBehaviour{
        
        private const float DefaultLowPassCutoff = 22000;

        [SerializeField] private AudioEffectChannel channel;
        [SerializeField] private float lowPassCutoff;
        [SerializeField] private AudioLowPassFilter lowPassFilter;

        private void Awake(){
            channel.OnSlowmoRequest.Subscribe(slowmo => {
                DOTween.To(
                    () => lowPassFilter.cutoffFrequency,
                    cutoff => lowPassFilter.cutoffFrequency = cutoff,
                    slowmo ? lowPassCutoff : DefaultLowPassCutoff,
                    0.3f
                ).SetTarget(lowPassFilter).SetUpdate(true);
            }).AddTo(this);
        }

    }
}
