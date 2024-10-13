using TMPro;
using UnityEngine;

namespace Source.Game {
    public class TimerDisplay : MonoBehaviour {
        private const int MinuteInSeconds = 60;
        
        [SerializeField] private TMP_Text _text;

        public void Set(float time) {
            int roundedTime = Mathf.CeilToInt(time);
            _text.text = $"{roundedTime / MinuteInSeconds:00}:{roundedTime % MinuteInSeconds:00}";
        }
    }
}
