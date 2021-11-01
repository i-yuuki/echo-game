﻿using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Echo.UI;

namespace Echo{
    public class GameManager : MonoBehaviour{

        public static GameManager Instance{ get; private set; }

        [SerializeField] private LoadingScreen loadingScreen;

        private bool isChangingScene;
        private string lastScene;
        private List<YieldInstruction> loadTasks;

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
            loadTasks = new List<YieldInstruction>();
        }

        void OnDestroy(){
            if(Instance == this){
                Instance = null;
            }
        }

        public void LoadScene(string name){
            if(isChangingScene) return;
            StartCoroutine(doLoadScene(lastScene, new string[]{name}));
            lastScene = name;
        }

        public void ReloadScene(){
            LoadScene(SceneManager.GetActiveScene().name);
        }

        public void AddSceneLoadTask(YieldInstruction task){
            if(isChangingScene){
                loadTasks.Add(task);
            }
        }

        private IEnumerator doLoadScene(string sceneToUnload, string[] scenesToLoad){
            isChangingScene = true;
            loadingScreen.Progress = 0;
            loadingScreen.Show();
            yield return SceneManager.UnloadSceneAsync(sceneToUnload);
            yield return loadScenesParallel(scenesToLoad);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scenesToLoad[0]));
            foreach(var task in loadTasks){
                yield return task;
            }
            loadTasks.Clear();
            loadingScreen.Hide();
            isChangingScene = false;
        }

        private IEnumerator loadScenesParallel(string[] scenesToLoad){
            AsyncOperation[] ops = scenesToLoad.Select(name => SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive)).ToArray();
            while(true){
                loadingScreen.Progress = ops.Average(op => op.progress);
                if(ops.All(op => op.isDone)){
                    break;
                }
                yield return null;
            }
        }

        private IEnumerator loadScenesSequential(string[] scenesToLoad){
            AsyncOperation op = SceneManager.LoadSceneAsync(scenesToLoad[0], LoadSceneMode.Additive);
            for(int i = 0;true;){
                loadingScreen.Progress = (float)i / scenesToLoad.Length + (1.0f / scenesToLoad.Length) * op.progress;
                if(op.isDone){
                    if(++ i >= scenesToLoad.Length) break;
                    op = SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
                }
                yield return null;
            }
        }

}
}
