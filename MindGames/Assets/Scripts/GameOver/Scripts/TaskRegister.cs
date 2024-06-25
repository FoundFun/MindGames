using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Wall.Scripts;

namespace GameOver.Scripts
{
    public class TaskRegister : IDisposable
    {
        private IReadOnlyList<TransparentObject> _wallsComplete;
        private GameObject _gameOverScreen;

        public void Initialize(IReadOnlyList<TransparentObject> taskCurrentWall, GameObject gameOverScreen)
        {
            _wallsComplete = taskCurrentWall;
            _gameOverScreen = gameOverScreen;
            
            foreach (TransparentObject transparentObject in _wallsComplete)
            {
                transparentObject.CompleteChanged += OnAllComplete;
            }
        }

        public void Dispose()
        {
            foreach (TransparentObject transparentObject in _wallsComplete)
            {
                transparentObject.CompleteChanged -= OnAllComplete;
            }
        }

        private void OnAllComplete()
        {
            int unCompleteValue = _wallsComplete.Count(wall => !wall.IsComplete);

            if (unCompleteValue <= 0)
            {
                _gameOverScreen.SetActive(true);
            }
        }
    }
}