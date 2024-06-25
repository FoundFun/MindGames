using Player.Configs;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Rigidbody _rigidbody;
        
        private PlayerInput _playerInput;
        private Vector3 _direction;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
        }

        private void OnDisable()
        {
            _playerInput.Disable();
        }

        private void Update()
        {
            _direction = transform.forward * _playerInput.Player.Move.ReadValue<Vector2>().y
                         + transform.right * _playerInput.Player.Move.ReadValue<Vector2>().x;
        }

        private void FixedUpdate()
        {
            _rigidbody.MovePosition(_rigidbody.position + _direction.normalized * _playerConfig.Speed * Time.fixedDeltaTime);
        }
    }
}