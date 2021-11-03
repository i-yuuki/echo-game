using UnityEngine;
using UnityEngine.UI;
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
            buttonPlay.onClick.AddListener(() => {
                playerMovement.enabled = true;
                Hide();
            });
            buttonSettings.onClick.AddListener(() => {
                // TODO show settings
                Hide();
            });
            buttonQuit.onClick.AddListener(() => Application.Quit());
        }

        private void Hide(){
            container.interactable = false;
            // TODO fade out
            container.gameObject.SetActive(false);
        }

    }
}
