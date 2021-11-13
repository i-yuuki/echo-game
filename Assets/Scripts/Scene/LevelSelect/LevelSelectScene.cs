using UnityEngine;
using Cysharp.Threading.Tasks;
using UniRx;
using Echo.Audio;
using Echo.Input;
using Echo.Save;

namespace Echo.UI.LevelSelect{
    public sealed class LevelSelectScene : MonoBehaviour{

        [SerializeField] private InputReader inputReader;
        [SerializeField] private AudioChannel channel;
        [SerializeField] private AudioCue seSelect;
        [SerializeField] private AudioCue seConfirm;
        [SerializeField] private SaveSystem saveSystem;
        [SerializeField] private LevelSelectLevel[] levels;
        [SerializeField] private LevelSelectIndicator[] indicators;
        [SerializeField] private GameObject iconPrev;
        [SerializeField] private GameObject iconNext;

        private int levelIdx;

        private void Start(){
            inputReader.EnableMenuInput();
            inputReader.OnMenuConfirm.Subscribe(_ => {
                var level = levels[levelIdx];
                if(level.IsSelectable && (!level.IsFinalBoss || saveSystem.SaveData.isFinalBossUnlocked)){
                    GameManager.Instance.LoadScene(level.SceneName);
                }
                channel.Request(seConfirm);
            }).AddTo(this);
            inputReader.OnMenuLeft.Subscribe(_ => SelectLevel(levelIdx - 1)).AddTo(this);
            inputReader.OnMenuRight.Subscribe(_ => SelectLevel(levelIdx + 1)).AddTo(this);
            levelIdx = 0;
            SelectLevel(0, true);
        }

        private void SelectLevel(int levelIdx, bool force = false){
            levelIdx = Mathf.Clamp(levelIdx, 0, levels.Length - 1);
            if(!force && this.levelIdx == levelIdx) return;
            int prevLevelIdx = this.levelIdx;
            this.levelIdx = levelIdx;

            levels[prevLevelIdx].Hide();
            levels[levelIdx].Show();
            indicators[prevLevelIdx].IsOn = false;
            indicators[levelIdx].IsOn = true;
            iconPrev.SetActive(levelIdx > 0);
            iconNext.SetActive(levelIdx < levels.Length - 1);

            channel.Request(seSelect);
        }

    }
}
