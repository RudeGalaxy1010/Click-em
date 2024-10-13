using TMPro;
using UnityEngine;

namespace Telegram {
    public class UserIdText : MonoBehaviour {
        [SerializeField] private TMP_Text _text;

        private void Start() {
            string userId = TelegramBridge.Instance.GetUserId();
            _text.text = userId;
        }
    }
}
