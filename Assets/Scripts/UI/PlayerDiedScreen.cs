using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using UniRx;
using Echo.Input;
using Echo.Player;

namespace Echo.UI{
    public sealed class PlayerDiedScreen : MonoBehaviour{

        [SerializeField] private InputReader inputReader;
        [SerializeField] private PlayerBase player;
        [SerializeField] private float fadeDuration;
        [SerializeField] private CanvasGroup container;
        [SerializeField] private Button buttonLevelSelect;

        private void Start(){
            player.OnDeath.Subscribe(_ => ShowAsync().Forget()).AddTo(this);
            buttonLevelSelect.onClick.AddListener(() => GameManager.Instance.LoadScene("LevelSelect"));
        }

        private async UniTaskVoid ShowAsync(){
            inputReader.EnableMenuInput();
            container.gameObject.SetActive(true);
            await container.DOFade(1, fadeDuration).From(0).SetLink(gameObject);
            buttonLevelSelect.Select();
        }

    }
}
