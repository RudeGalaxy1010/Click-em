using UnityEngine;

namespace Source.Infrastructure {
    public interface IAssetsProvider {
        T Instantiate<T>(string path) where T : Object;
        T Instantiate<T>(string path, Transform parent) where T : Object;
        T Load<T>(string path) where T : Object;
        T[] LoadAll<T>(string path) where T : Object;
    }
}
