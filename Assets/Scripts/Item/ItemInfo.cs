using UnityEngine;

namespace Echo.Item{
    [CreateAssetMenu(fileName = "New Item", menuName = "ScriptableObject/Item/ItemInfo")]
    public sealed class ItemInfo : ScriptableObject{

        [SerializeField] private new string name;
        [SerializeField] private Sprite icon;
        [SerializeField] private Sprite nameImage;
        [TextArea()]
        [SerializeField] private string description;
        [SerializeField] private ItemEffectType effect;

        public string Name => name;
        public Sprite Icon => icon;
        public Sprite NameImage => nameImage;
        public string Description => description;
        public ItemEffectType Effect => effect;

    }
}
