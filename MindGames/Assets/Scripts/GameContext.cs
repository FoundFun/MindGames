using System.Collections.Generic;
using GameOver.Scripts;
using Spawner.Scripts;
using UnityEngine;
using Wall.Scripts;

public class GameContext : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _currentPoint;
    [SerializeField] private Transform _stackPoint;
    [SerializeField] private List<WallConfig> _wallConfigs;
    [SerializeField] private TransparentObject _transparentObject;
    [SerializeField] private SpawnerWallConfig _spawnerWallConfig;
    [SerializeField] private GameObject _gameOverScreen;
    
    public async void Start()
    {
        SpawnerWall spawnerWall = new SpawnerWall(_spawnerWallConfig);
        
         var targetGameColors = await spawnerWall.SpawnTargetWall(_wallConfigs, _targetPoint);
         var taskCurrentWall = await spawnerWall.SpawnCurrentWall(_transparentObject, _currentPoint, targetGameColors);
         await spawnerWall.SpawnStackWall(_stackPoint);

         TaskRegister taskRegister = new TaskRegister();
         taskRegister.Initialize(taskCurrentWall, _gameOverScreen);
    }
}
