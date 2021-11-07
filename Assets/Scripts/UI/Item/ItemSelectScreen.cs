using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using Echo.Input;
using Echo.Item;

namespace Echo.UI.Item{
    public sealed class ItemSelectScreen : MonoBehaviour{

        [SerializeField] private ItemListItem[] items;
        [SerializeField] private CanvasGroup container;

        private void Start(){
            foreach(var item in items){
                item.OnClick.Subscribe(_ => {
                    Close();
                }).AddTo(this);
            }
        }

        public async UniTask<ItemInfo> Open(){
            container.interactable = true;
            gameObject.SetActive(true);
            container.DOFade(1, 0.3f).From(0).ToUniTask().Forget();
            EventSystem.current.SetSelectedGameObject(items[0].gameObject);
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

    }
}
