using Source.Init;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Game {
    public class GameSceneEmitter : MonoBehaviour {
        public Button ClickArea;
        public Transform FloatingScoreSpawnPoint;
        public TimerDisplay TimerDisplay;
        public ScoreDisplay ScoreDisplay;
        public GameOverPanel GameOverPanel;
        public LoadingBar LoadingBar;
    }
}
