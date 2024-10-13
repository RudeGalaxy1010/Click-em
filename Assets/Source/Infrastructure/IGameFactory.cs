using UnityEngine;

namespace Source.Infrastructure {
    public interface IGameFactory : IService {

        void CreateFloatingScore(int score, Transform spawnPoint, Vector2 offsets);
    }
}
