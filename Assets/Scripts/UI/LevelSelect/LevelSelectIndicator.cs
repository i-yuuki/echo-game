using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Echo.UI.LevelSelect{
    public sealed class LevelSelectIndicator : MonoBehaviour{

        [SerializeField] private Image image;
        [SerializeField] private Sprite spriteOn;
        [SerializeField] private Sprite spriteOff;

        public bool IsOn{
            set{
                image.sprite = value ? spriteOn : spriteOff;
            }
        }

    }
}
