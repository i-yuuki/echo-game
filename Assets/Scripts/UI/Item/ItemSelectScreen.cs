using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using TMPro;
using UniRx;
using Echo.Item;

namespace Echo.UI.Item{
    public sealed class ItemSelectScreen : MonoBehaviour{

        [SerializeField] private ItemListItem[] items;
        [SerializeField] private CanvasGroup container;
        [SerializeField] private Image labelName;
        [SerializeField] private TextMeshProUGUI labelDescription;

        private void Awake(){
            foreach(var item in items){
                item.OnSelect.Subscribe(_ => DisplayItemInfo(item.ItemInfo)).AddTo(this);
            }
        }

        public async UniTask<ItemInfo> Open(){
            container.interactable = true;
            gameObject.SetActive(true);
            container.DOFade(1, 0.3f).From(0).ToUniTask().Forget();
            items[0].Select();
            var tcs = new UniTaskCompletionSource<ItemInfo>();
            using(var cts = new CancellationTokenSource()){
                foreach(var item in items){
                    item.OnClick.Subscribe(_ => tcs.TrySetResult(item.ItemInfo)).AddTo(cts.Token);
                }
                var itemInfo = await tcs.Task;
                Close();
                return itemInfo;
            }
        }

        private void Close(){
            CloseAsync().Forget();
        }

        private async UniTaskVoid CloseAsync(){
            container.interactable = false;
            await container.DOFade(0, 0.2f).From(1);
            gameObject.SetActive(false);
        }

        private void DisplayItemInfo(ItemInfo itemInfo){
            labelName.sprite = itemInfo.NameImage;
            labelDescription.text = itemInfo.Description;
        }

    }
}
