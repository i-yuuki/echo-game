using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Echo.Input;

namespace Echo.Scene.Title{
    public sealed class TitleScene : MonoBehaviour{

        [SerializeField] private InputReader inputReader;
        [SerializeField] private CanvasGroup container;
        [SerializeField] private Button buttonPlay;
        [SerializeField] private Button buttonSettings;
        [SerializeField] private Button buttonQuit;

        void Start(){
            inputReader.EnableMenuInput();
            buttonPlay.onClick.AddListener(() => PlayAsync().Forget());
            buttonSettings.onClick.AddListener(() => {
                // TODO show settings
                Hide();
            });
            buttonQuit.onClick.AddListener(() => Application.Quit());
        }

        private async UniTaskVoid PlayAsync(){
            await HideAsync();
            inputReader.EnableGameplayInput();
            // maybe display movement controls here
        }

        private void Hide(){
            HideAsync().Forget();
        }

        private async UniTask HideAsync(){
            container.interactable = false;
            await container.DOFade(0, 0.2f);
            container.gameObject.SetActive(false);
        }

    }
}
