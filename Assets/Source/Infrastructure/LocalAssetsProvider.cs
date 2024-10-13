using UnityEngine;

namespace Source.Infrastructure {
    public class LocalAssetsProvider : IAssetsProvider {
        public T Instantiate<T>(string path) where T : Object {
            T resource = Resources.Load<T>(path);
            return Object.Instantiate(resource);
        }
        
        public T Load<T>(string path) where T : Object {
            return Resources.Load<T>(path);
        }

        public T[] LoadAll<T>(string path) where T : Object {
            return Resources.LoadAll<T>(path);
        }
    }
}
