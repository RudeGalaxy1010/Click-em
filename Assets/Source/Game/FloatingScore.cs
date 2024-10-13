using TMPro;
using UnityEngine;

namespace Source.Game {
    public class FloatingScore : MonoBehaviour {
        [SerializeField] private float _speed;
        [SerializeField] private float _alphaSpeed;
        [SerializeField] private float _showTime;
        [SerializeField] private TMP_Text _text;

        private float _time;
        
        public void Set(int score) {
            _time = 0;
            _text.text = $"+{score}";
        }

        private void Update() {
            _time += Time.deltaTime;
            
            Vector3 position = transform.position;
            transform.position = Vector3.MoveTowards(
                position, 
                position + Vector3.up, 
                _speed * Time.deltaTime);
            _text.alpha -= _alphaSpeed * Time.deltaTime;

            if (_time > _showTime) {
                Destroy(gameObject);
            }
        }
    }
}
