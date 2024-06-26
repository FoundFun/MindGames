using Unity.Netcode;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Scripts
{
    public class PlayerMouseController : NetworkBehaviour
    {
        [SerializeField] private Transform _playerItemPosition;
        [SerializeField] private float _distance = 5f;
        
        private PlayerInput _playerInput;
        private TakeObject _currentTakeObject;
        private bool _isTake;

        private void Awake()
        {
            _playerInput = new PlayerInput();
        }

        private void OnEnable()
        {
            _playerInput.Enable();
            _playerInput.Player.Take.canceled += OnTake;
        }

        private void OnDisable()
        {
            _playerInput.Player.Take.canceled -= OnTake;
            _playerInput.Disable();
        }

        private void OnTake(InputAction.CallbackContext obj)
        {
            if (!IsOwner)
            {
                return;
            }
            
            if (_currentTakeObject != null)
            {
                _currentTakeObject.Throw();
                _currentTakeObject = null;
                return;
            }
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out TakeObject takeObject))
                {
                    _currentTakeObject = takeObject;
                    takeObject.Take(_playerItemPosition);
                }
            }
        }
    }
}