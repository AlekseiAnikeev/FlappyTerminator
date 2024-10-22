using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class BirdMover : MonoBehaviour
    {
        [SerializeField] private float _tapForce = 4f;
        [SerializeField] private float _speed =2.5f;
        [SerializeField] private float _rotationSpeed = 1f;
        [SerializeField] private float _maxRotationZ = 35f;
        [SerializeField] private float _minRotationZ = -60f;

        private Vector3 _startPosition;
        private Rigidbody2D _rigidbody2D;
        private Quaternion _maxRotation;
        private Quaternion _minRotation;
        private Cannon _cannon;

        private void Start()
        {
            _startPosition = transform.position;
            _rigidbody2D = GetComponent<Rigidbody2D>();
            
            _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
            _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
                transform.rotation = _maxRotation;
            }

            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        }

        public void Reset()
        {
            transform.position = _startPosition;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            _rigidbody2D.velocity = Vector2.zero;
        }
    }
}