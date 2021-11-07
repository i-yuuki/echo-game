using System;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Echo.Item;

namespace Echo.UI.Item{
    public sealed class ItemListItem : MonoBehaviour{

        [SerializeField] private ItemInfo itemInfo;
        [SerializeField] private Image icon;
        [SerializeField] private Button button;

        private readonly Subject<Unit> onClick = new Subject<Unit>();

        public ItemInfo ItemInfo => itemInfo;

        public IObservable<Unit> OnClick => onClick;

        private void Awake(){
            icon.sprite = itemInfo.Icon;
            button.onClick.AddListener(() => onClick.OnNext(Unit.Default));
        }

    }
}
