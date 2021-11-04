using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cysharp.Threading.Tasks;
using Echo.UI;

namespace Echo{
    public class GameManager : MonoBehaviour{

        public static GameManager Instance{ get; private set; }

        [SerializeField] private LoadingScreen loadingScreen;

        private bool isChangingScene;
        private string lastScene;

        void Awake(){
            if(Instance){
                Destroy(gameObject);
                return;
            }
            Instance = this;
            if(SceneManager.sceneCount > 1){
                lastScene = SceneManager.GetActiveScene().name;
            }else{
                SceneManager.LoadScene(0, LoadSceneMode.Additive);
                lastScene = SceneManager.GetSceneByBuildIndex(0).name;
            }
        }

        void OnDestroy(){
            if(Instance == this){
                Instance = null;
            }
        }

        public void LoadScene(string name){
            if(isChangingScene) return;
            LoadSceneAsync(lastScene, new string[]{name}).Forget();
            lastScene = name;
        }

        public void ReloadScene(){
            LoadScene(SceneManager.GetActiveScene().name);
        }

        private async UniTask LoadSceneAsync(string sceneToUnload, string[] scenesToLoad){
            isChangingScene = true;
            loadingScreen.Progress = 0;
            await loadingScreen.ShowAsync();
            await SceneManager.UnloadSceneAsync(sceneToUnload);
            await LoadScenesParallelAsync(scenesToLoad);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scenesToLoad[0]));
            await loadingScreen.HideAsync();
            isChangingScene = false;
        }

        private async UniTask LoadScenesParallelAsync(string[] scenesToLoad){
            AsyncOperation[] ops = scenesToLoad.Select(name => SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive)).ToArray();
            while(true){
                loadingScreen.Progress = ops.Average(op => op.progress);
                if(ops.All(op => op.isDone)){
                    break;
                }
                await UniTask.Yield();
            }
        }

    }
}
