using Unity.Netcode;
using UnityEngine;

namespace Player.Scripts
{
    public class PlayerCamera : NetworkBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private Transform _orientation;
        [SerializeField] private float _clampRotation = 80;
        [SerializeField] private float _speed = 10;
        [SerializeField] private float _sensX;
        [SerializeField] private float _sensY;

        private const string AxisMouseX = "Mouse X";
        private const string AxisMouseY = "Mouse Y";
        
        private float _yRotation;
        private float _xRotation;

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void LateUpdate()
        {
            if (!IsOwner)
            {
                return;
            }   
            
            float mouseX = Input.GetAxisRaw(AxisMouseX) * Time.deltaTime * _sensX;
            float mouseY = Input.GetAxisRaw(AxisMouseY) * Time.deltaTime * _sensY;

            _yRotation += mouseX;
            _xRotation -= mouseY;

            _xRotation = Mathf.Clamp(_xRotation, -_clampRotation, _clampRotation);
            
            transform.rotation = Quaternion.Lerp(transform.rotation , Quaternion.Euler(new Vector3(_xRotation, _yRotation, 0)), _speed * Time.deltaTime);
            _orientation.rotation = Quaternion.Lerp(_orientation.rotation , Quaternion.Euler(new Vector3(0, _yRotation, 0)), _speed * Time.deltaTime);
        }

        public override void OnNetworkSpawn() 
        {
            base.OnNetworkSpawn();
            _camera.gameObject.SetActive(IsOwner);
        }
    }
}