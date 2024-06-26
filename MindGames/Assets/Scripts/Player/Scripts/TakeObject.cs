using Unity.Netcode;
using UnityEngine;

namespace Player.Scripts
{
    public class TakeObject : NetworkBehaviour
    {
        private Rigidbody _rigidbody;
        private Transform _playerItemPosition;
        private bool _isTake = true;
        
        public ColorTag TargetColor { get; private set; }

        public void Initialize(ColorTag color)
        {
            TargetColor = color;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            if (_rigidbody.isKinematic && _playerItemPosition != null)
            {
                transform.position = _playerItemPosition.position;
            }
        }

        public void Take(Transform playerItemPosition)
        {
            if (!_isTake)
                return;
            
            _playerItemPosition = playerItemPosition;
            _rigidbody.isKinematic = true;
            _rigidbody.useGravity = false;
            _rigidbody.MovePosition(_playerItemPosition.position);
        }

        public void Throw()
        {
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
            _playerItemPosition = null;
        }

        public void Freeze()
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        }

        public void IsTake(bool active)
        {
            _isTake = active;
        }
    }
}