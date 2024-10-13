using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Telegram {
    public class TelegramBridge {
        private static TelegramBridge _instance;
        
#if !UNITY_EDITOR || UNITY_WEBGL
        [DllImport("__Internal")]
        private static extern int getUserId();
#endif
        
        public static TelegramBridge Instance => _instance ??= new TelegramBridge();

        public string GetUserId() {
#if UNITY_EDITOR || !UNITY_WEBGL
            return "test-user";
#endif
            try {
                return BufferToString(getUserId());
            }
            catch (Exception e) {
                Debug.LogError("Error attempt to call 'getUserId': " + e.Message);
            }

            return string.Empty;
        }

        private string BufferToString(int buffer) {
            try {
                if (buffer != 0) {
                    return Marshal.PtrToStringUTF8((IntPtr)buffer);
                }

                Debug.LogWarning($"Failed to get string from buffer ('{buffer}')");
            }
            catch (Exception e) {
                Debug.LogWarning($"Failed to get string from buffer ('{buffer}') : {e.Message}");
            }

            return string.Empty;
        }
    }
}
