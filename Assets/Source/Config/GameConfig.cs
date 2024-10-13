using UnityEngine;

namespace Source.Config {
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = ConfigConstants.Root + nameof(GameConfig))]
    public class GameConfig : ScriptableObject {
        public float LevelTime = 30;
        public int ScorePerClick = 1;
        public Vector2 FloatingScoreOffsets = new Vector2(1, 0.5f);
    }
}
