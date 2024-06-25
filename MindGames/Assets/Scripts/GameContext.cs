using System.Collections.Generic;
using Spawner.Scripts;
using UnityEngine;
using Wall.Scripts;

public class GameContext : MonoBehaviour
{
    [SerializeField] private Transform _targetPoint;
    [SerializeField] private Transform _currentPoint;
    [SerializeField] private Transform _stackPoint;
    [SerializeField] private List<WallConfig> _wallConfigs;
    [SerializeField] private WallConfig _transparentWallConfigs;
    [SerializeField] private SpawnerWallConfig _spawnerWallConfig;

    public async void Start()
    {
        SpawnerWall spawnerWall = new SpawnerWall(_spawnerWallConfig);
        
         var targetGameColors = await spawnerWall.SpawnTargetWall(_wallConfigs, _targetPoint);
         await spawnerWall.SpawnCurrentWall(_transparentWallConfigs, _currentPoint);
         await spawnerWall.SpawnStackWall(_stackPoint);
    }
}
