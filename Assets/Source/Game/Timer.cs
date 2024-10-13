using System;
using System.Collections;
using Source.Infrastructure;
using UnityEngine;

namespace Source.Game {
    public class Timer {
        private readonly ICoroutineRunner _coroutineRunner;
        private float _timeLeft;

        public Timer(ICoroutineRunner coroutineRunner) {
            _coroutineRunner = coroutineRunner;
        }

        public void Start(float time, Action<float> onChange = null, Action onEnd = null) {
            _timeLeft = time;
            onChange?.Invoke(_timeLeft);
            _coroutineRunner.StartCoroutine(Run(onChange, onEnd));
        }

        private IEnumerator Run(Action<float> onChange = null, Action onEnd = null) {
            while (_timeLeft >= 0) {
                _timeLeft -= Time.deltaTime;
                onChange?.Invoke(_timeLeft);
                yield return null;
            }
            
            _timeLeft = 0;
            onChange?.Invoke(_timeLeft);
            onEnd?.Invoke();
        }
    }
}
