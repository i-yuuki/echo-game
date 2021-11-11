using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Echo.Player;

namespace Echo.UI{
    public sealed class PlayerLevelDisplay : MonoBehaviour{
        
        [SerializeField] PlayerBase player;
        [SerializeField] Slider slider;

        private void Start(){
            slider.maxValue = player.MaxLevel;
            player.OnLevelChange.Subscribe(level => slider.value = level).AddTo(this);
        }

    }
}
