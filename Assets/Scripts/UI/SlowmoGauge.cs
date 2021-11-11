using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Echo.Extensions;
using Echo.Player;

namespace Echo.UI{
    public sealed class SlowmoGauge : MonoBehaviour{
        
        [SerializeField] PlayerSlowmo playerSlowmo;
        [SerializeField] Slider slider;


        private void Start(){
            playerSlowmo.OnChargeChange.Subscribe(charge => slider.value = charge).AddTo(this);
        }

    }
}
