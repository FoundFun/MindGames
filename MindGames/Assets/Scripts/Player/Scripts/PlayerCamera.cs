using UnityEngine;

namespace Player.Scripts
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private Transform _orientation;
        [SerializeField] private float _clampRotation = 80;
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
            float mouseX = Input.GetAxisRaw(AxisMouseX) * Time.deltaTime * _sensX;
            float mouseY = Input.GetAxisRaw(AxisMouseY) * Time.deltaTime * _sensY;

            _yRotation += mouseX;
            _xRotation -= mouseY;

            _xRotation = Mathf.Clamp(_xRotation, -_clampRotation, _clampRotation);
            
            transform.rotation = Quaternion.Euler(_xRotation, _yRotation, 0);
            _orientation.rotation = Quaternion.Euler(0, _yRotation, 0);
        }
    }
}