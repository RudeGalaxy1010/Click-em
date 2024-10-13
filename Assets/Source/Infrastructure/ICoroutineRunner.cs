using System.Collections;
using UnityEngine;

namespace Source.Infrastructure {
    public interface ICoroutineRunner {
        public Coroutine StartCoroutine(IEnumerator coroutine);
    }
}
