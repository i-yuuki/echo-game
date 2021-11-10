using UnityEngine;
using UniRx;
using Echo.Player;

namespace Echo.UI{
    public sealed class ReflectTypeDisplay : MonoBehaviour{
        
        [SerializeField] PlayerReflectBullet player;
        [SerializeField] ReflectTypeDisplayItem[] items;

        private void Start(){
            player.OnReflectTypeChange.Subscribe(type => {
                foreach(var item in items){
                    item.gameObject.SetActive(item.Type == type);
                }
            });
        }

    }
}
