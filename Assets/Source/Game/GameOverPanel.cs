using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Source.Game {
    public class GameOverPanel : MonoBehaviour {
        private readonly string WinnerColor = nameof(Color.white);
        
        [SerializeField] private TMP_Text _winnerText;
        
        public Button BackButton;

        public void Open(string winnerName) {
            _winnerText.text = $"<color={WinnerColor}>{winnerName}</color>\nis the winner!";
            gameObject.SetActive(true);
        }
    }
}
