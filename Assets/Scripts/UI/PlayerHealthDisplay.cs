using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Echo.Extensions;
using Echo.Player;

namespace Echo.UI{
    public sealed class PlayerHealthDisplay : MonoBehaviour{
        
        [SerializeField] private float spriteSize;
        [SerializeField] PlayerBase player;
        [SerializeField] Slider slider;

        public PlayerBase Player{
            set => player = value;
        }

        private void Start(){
            slider.maxValue = player.MaxHealth;
            var t = slider.transform as RectTransform;
            t.sizeDelta = t.sizeDelta.WithX(spriteSize * player.MaxHealth);

            player.OnHealthChange.Subscribe(health => slider.value = health).AddTo(this);
        }

    }
}
