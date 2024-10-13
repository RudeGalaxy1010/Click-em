using System;
using System.Text;
using Cysharp.Threading.Tasks;
using NativeWebSocket;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Source.Remote.Data;
using UnityEngine;

namespace Source.Remote {
    public static class Server {
        private static readonly WebSocket _webSocket;
        private static MethodsHandlers _methodsHandlers;

        static Server() {
            _webSocket = new WebSocket(Constants.WebSocketApiUrl);
            _webSocket.OnMessage += OnMessageReceive;
        }

        public static async UniTask<WebSocketState> OpenSocketConnection(MethodsHandlers methodsHandlers) {
            _methodsHandlers = methodsHandlers;
            await _webSocket.Connect();
            return _webSocket.State;
        }
        
        public static void CreateRoom(RoomData roomData) {
            string data = JsonConvert.SerializeObject(roomData);
            SendWebSocketMessage(Constants.Method.CreateRoom, data);
        }

        public static void ConnectToRoom(RoomData roomData) {
            string data = JsonConvert.SerializeObject(roomData);
            SendWebSocketMessage(Constants.Method.ConnectToRoom, data);
        }

        public static void SendUserData(UserData userData) {
            string data = JsonConvert.SerializeObject(userData);
            SendWebSocketMessage(Constants.Method.UserInfo, data);
        }

        private static async void SendWebSocketMessage(string methodName, string data) {
            if (_webSocket.State != WebSocketState.Open) {
                Debug.LogError($"Error! Wrong web socket state: {_webSocket.State}");
                return;
            }
            
            JObject tokens = new JObject {
                new JProperty("MethodName", methodName),
                new JProperty("Data", data)
            };
            
            await _webSocket.SendText(tokens.ToString());
        }

        private static void OnMessageReceive(byte[] bytes) {
            string message = Encoding.UTF8.GetString(bytes);
            JObject messageTokens = JObject.Parse(message);
            
            string methodName = (string)messageTokens.SelectToken("MethodName");

            if (methodName == null || string.IsNullOrWhiteSpace(methodName)) {
                Debug.LogError("'method name' was not provided by web socket!");
                return;
            }
            
            string data = (string)messageTokens.SelectToken("Data");

            if (data == null || string.IsNullOrWhiteSpace(data)) {
                Debug.LogError("'data' was not provided by web socket!");
                return;
            }
            
            switch (methodName) {
                // Get available rooms list
                case Constants.Method.AvailableRooms:
                    AvailableRoomsData roomsData = DeserializeSafe<AvailableRoomsData>(data);
                    _methodsHandlers.RoomHandler.UpdateAvailableRooms(roomsData);
                    break;
                // Other player connected to room
                case Constants.Method.ConnectToRoom:
                    UserData connectedUserData = DeserializeSafe<UserData>(data);
                    _methodsHandlers.PlayerConnectedHandler.HandlePlayerConnected(connectedUserData);
                    break;
                // Other player score update
                case Constants.Method.UserInfo:
                    UserData userData = DeserializeSafe<UserData>(data);
                    _methodsHandlers.UserDataHandler.HandleUserData(userData);
                    break;
                // Sync game over
                case Constants.Method.GameOver:
                    GameOverData gameOverData = DeserializeSafe<GameOverData>(data);
                    _methodsHandlers.GameOverHandler.HandleGameOver(gameOverData);
                    break;
                default:
                    Debug.LogError($"Unknown 'method name' received: '{methodName}'");
                    break;
            }
        }

        private static TData DeserializeSafe<TData>(string data) {
            try {
                return JsonConvert.DeserializeObject<TData>(data);
            }
            catch (Exception exception) {
                Debug.LogError($"Failed to parse data: {exception.Message}");
            }

            return default;
        }
    }
}
