using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Echo.Player;

namespace Echo.UI{
    public sealed class ReflectTypeDisplayItem : MonoBehaviour{
        
        [SerializeField] ReflectType type;

        public ReflectType Type => type;

    }
}
