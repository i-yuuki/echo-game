using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Echo.Player;

namespace Echo.Scene.Title{
    public sealed class TitleScene : MonoBehaviour{

        [SerializeField] private CanvasGroup container;
        [SerializeField] private Button buttonPlay;
        [SerializeField] private Button buttonSettings;
        [SerializeField] private Button buttonQuit;
        [SerializeField] private PlayerMovement playerMovement;

        void Start(){
            playerMovement.enabled = false;
            buttonPlay.onClick.AddListener(() => PlayAsync().Forget());
            buttonSettings.onClick.AddListener(() => {
                // TODO show settings
                Hide();
            });
            buttonQuit.onClick.AddListener(() => Application.Quit());
        }

        private async UniTaskVoid PlayAsync(){
            await HideAsync();
            playerMovement.enabled = true;
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
