using Source.Constants;
using Source.Game;
using UnityEngine;

namespace Source.Infrastructure {
    public class GameFactory : IGameFactory {
        private readonly IAssetsProvider _assetsProvider;
        
        public GameFactory(IAssetsProvider assetsProvider) {
            _assetsProvider = assetsProvider;
        }

        public void CreateFloatingScore(int score, Transform spawnPoint, Vector2 offsets) {
            float randomX = Random.Range(-offsets.x, offsets.x);
            float randomY = Random.Range(-offsets.y, offsets.y);

            FloatingScore floatingScore =
                _assetsProvider.Instantiate<FloatingScore>(AssetsPath.FloatingScore, spawnPoint);
            floatingScore.transform.position =
                new Vector3(spawnPoint.position.x + randomX, spawnPoint.position.y + randomY);
            floatingScore.Set(score);
        }
    }
}
