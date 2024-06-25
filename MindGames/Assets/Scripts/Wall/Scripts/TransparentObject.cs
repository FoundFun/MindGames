using System;
using Player.Scripts;
using UnityEngine;

namespace Wall.Scripts
{
    public class TransparentObject : MonoBehaviour
    {
        public ColorTag _targetColor;

        public bool IsComplete;

        public event Action CompleteChanged;

        public void SetColor(ColorTag targetGameColors)
        {
            _targetColor = targetGameColors;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TakeObject takeObject) && takeObject.TargetColor == _targetColor)
            {
                IsComplete = true;
                CompleteChanged?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out TakeObject takeObject))
            {
                IsComplete = false;
                CompleteChanged?.Invoke();
            }
        }
    }
}