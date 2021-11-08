using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Echo.Extensions;
using Echo.Player;
using TMPro;

namespace Echo.UI{
    public class PlayerLevelDisplay : MonoBehaviour{
        
        [SerializeField] PlayerBase player;
        [SerializeField] TextMeshProUGUI labelLevel;

        private void Start(){
            player.OnLevelChange.Subscribe(level => labelLevel.text = level.ToString()).AddTo(this);
        }

    }
}
