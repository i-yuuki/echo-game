using System;
using UnityEngine;
using UniRx;
using Echo.Input;

namespace Echo.Player{
    [RequireComponent(typeof(PlayerBase))]
    public sealed class PlayerSlowmo : MonoBehaviour{
        
        private PlayerBase player;
        [SerializeField] private FloatReactiveProperty charge;
        [SerializeField] private float minCharge;
        [SerializeField] private float timeScale;
        [SerializeField] private float consumption;
        [SerializeField] private InputReader inputReader;

        private readonly ReactiveProperty<bool> isInSlowmo = new ReactiveProperty<bool>();
        public float Charge{
            get => charge.Value;
            set => charge.Value = Mathf.Clamp01(value);
        }

        public IObservable<float> OnChargeChange => charge;
        public IObservable<bool> OnSlowmoChange => isInSlowmo;

        private void Reset(){
            player = GetComponent<PlayerBase>();
        }

        private void Awake(){
            inputReader.OnSlowmo.Subscribe(_ => ToggleSlowmo()).AddTo(this);
        }

        private void Update(){
            if(!isInSlowmo.Value) return;
            charge.Value = Math.Max(0, charge.Value - Time.unscaledDeltaTime * consumption);
            if(charge.Value == 0){
                ToggleSlowmo();
            }
        }

        private void ToggleSlowmo(){
            if(!isInSlowmo.Value){
                if(charge.Value < minCharge) return;
            }
            isInSlowmo.Value = !isInSlowmo.Value;
            if(isInSlowmo.Value){
                Time.timeScale = timeScale;
                // maybe control BGM here
            }else{
                Time.timeScale = 1;
            }
        }

        public void StopSlowmo(){
            if(isInSlowmo.Value){
                ToggleSlowmo();
            }
        }

    }
}
