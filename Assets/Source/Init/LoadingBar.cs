using UnityEngine;
using UnityEngine.UI;

namespace Source.Init {
    public class LoadingBar : MonoBehaviour {
        [SerializeField] private Image _loadingBar;
        
        public void SetProgress(float progress) {
            _loadingBar.fillAmount = progress;
        }
    }
}
