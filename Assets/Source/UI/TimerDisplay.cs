using TMPro;
using UnityEngine;

namespace Source.UI {
    public class TimerDisplay : MonoBehaviour {
        private const int MinuteInSeconds = 60;
        
        [SerializeField] private TMP_Text _text;

        public void Set(float time) {
            int roundedTime = Mathf.FloorToInt(time);
            _text.text = $"{roundedTime / MinuteInSeconds:00}:{roundedTime % MinuteInSeconds:00}";
        }
    }
}
