using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UniRx;
using Echo.Item;

namespace Echo.UI.Item{
    public sealed class ItemListItem : MonoBehaviour, ISelectHandler{

        [SerializeField] private ItemInfo itemInfo;
        [SerializeField] private Image icon;
        [SerializeField] private Button button;

        private readonly Subject<Unit> onClick = new Subject<Unit>();
        private readonly Subject<Unit> onSelect = new Subject<Unit>();

        public ItemInfo ItemInfo => itemInfo;

        public IObservable<Unit> OnClick => onClick;
        public IObservable<Unit> OnSelect => onSelect;

        private void Awake(){
            icon.sprite = itemInfo.Icon;
            button.onClick.AddListener(() => onClick.OnNext(Unit.Default));
        }

        public void Select(){
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(gameObject);
        }

        void ISelectHandler.OnSelect(BaseEventData eventData){
            onSelect.OnNext(Unit.Default);
        }

    }
}
