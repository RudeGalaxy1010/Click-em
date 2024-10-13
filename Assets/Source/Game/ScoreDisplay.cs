using TMPro;
using UnityEngine;

namespace Source.Game {
    public class ScoreDisplay : MonoBehaviour {
        [SerializeField] private TMP_Text _scoreText;

        public void SetScore(int userScore, int otherScore) {
            _scoreText.text = userScore >= otherScore
                ? $"You: {userScore}\n<alpha=#C8>Other: {otherScore}"
                : $"Other: {otherScore}\n<alpha=#C8>You: {userScore}";
        }
    }
}
