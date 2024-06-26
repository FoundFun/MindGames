using Player.Configs;
using Unity.Netcode;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerMover : NetworkBehaviour
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
            if (!IsOwner)
            {
                return;
            }
            
            _direction = transform.forward * _playerInput.Player.Move.ReadValue<Vector2>().y
                         + transform.right * _playerInput.Player.Move.ReadValue<Vector2>().x;
        }

        private void FixedUpdate()
        {
            if (!IsOwner)
            {
                return;
            }
            
            _rigidbody.MovePosition(_rigidbody.position + _direction.normalized * _playerConfig.Speed * Time.fixedDeltaTime);
        }
    }
}