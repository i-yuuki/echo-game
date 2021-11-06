using UnityEngine;
using UnityEngine.EventSystems;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace Echo.UI{
    public sealed class LevelCompleteDisplay : MonoBehaviour{

        [SerializeField] private CanvasGroup container;
        [SerializeField] private GameObject selectButtonOnShow;

        public void Show(){
            ShowAsync().Forget();
        }

        public async UniTask ShowAsync(){
            gameObject.SetActive(true);
            await container.DOFade(1, 0.3f).From(0);
            EventSystem.current.SetSelectedGameObject(selectButtonOnShow);
        }

    }
}
