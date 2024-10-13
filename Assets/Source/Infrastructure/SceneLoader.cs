using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Infrastructure {
    public class SceneLoader {
        private const string MenuScene = "MenuScene";
        private const string GameScene = "GameScene";

        public AsyncOperation LoadMenuSceneAsync(Action onLoaded = null) {
            if (SceneManager.GetActiveScene().name != GameScene) {
                return SceneManager.LoadSceneAsync(MenuScene);
            }
            
            onLoaded?.Invoke();
            return null;
        }

        public AsyncOperation LoadGameSceneAsync(Action onLoaded = null) {
            if (SceneManager.GetActiveScene().name != GameScene) {
                return SceneManager.LoadSceneAsync(GameScene);
            }
            
            onLoaded?.Invoke();
            return null;
        }
    }
}
