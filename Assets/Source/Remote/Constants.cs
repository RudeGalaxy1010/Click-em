namespace Source.Remote {
    public static class Constants {
        public const string ApiUrl = "https://localhost:2567";
        public const string WebSocketApiUrl = "ws://localhost:2567";
        
        public static class Method {
            public const string CreateRoom = "CreateRoom";
            public const string AvailableRooms = "AvailableRooms";
            public const string ConnectToRoom = "ConnectToRoom";
            public const string UserInfo = "UserInfo";
            public const string GameOver = "GameOver";
        }
    }
}
