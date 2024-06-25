using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Wall.Scripts;

namespace Spawner.Scripts
{
    public class SpawnerWall
    {
        private readonly SpawnerWallConfig _spawnerWallConfig;
        
        private List<GameObject> _targetStackWalls = new List<GameObject>();

        public SpawnerWall(SpawnerWallConfig spawnerWallConfig)
        {
            _spawnerWallConfig = spawnerWallConfig;
        }
  
        public Task<List<Color>> SpawnTargetWall(List<WallConfig> wallConfigs, Transform targetPoint)
        {
            List<Color> colors = new List<Color>();
            
            for (int y = 0; y < _spawnerWallConfig.Height; ++y)
            {
                for (int z = 0; z < _spawnerWallConfig.Width; ++z)
                {
                    int index = Random.Range(0, wallConfigs.Count);
                    
                    Object.Instantiate(wallConfigs[index].Prefab,
                        new Vector3(targetPoint.position.x, targetPoint.position.y + y,targetPoint.position.z + z),
                        Quaternion.identity, targetPoint);
                    
                    colors.Add(wallConfigs[index].Color);
                    _targetStackWalls.Add(wallConfigs[index].Prefab);
                }
            }

            return Task.FromResult(colors);
        }

        public Task SpawnStackWall(Transform targetPoint)
        {
            for (int i = 0; i < _targetStackWalls.Count; i++)
            {
                var x = Random.Range(1, 5);
                var z = Random.Range(1, 5);
                
                Object.Instantiate(_targetStackWalls[i],
                    new Vector3(targetPoint.position.x + x, targetPoint.position.y,targetPoint.position.z + z),
                    Quaternion.identity, targetPoint);
            }
            
            return Task.CompletedTask;
        }

        public Task SpawnCurrentWall(WallConfig transparentWallConfigs, Transform targetPoint)
        {
            for (int y = 0; y < _spawnerWallConfig.Height; ++y)
            {
                for (int z = 0; z < _spawnerWallConfig.Width; ++z)
                {
                    Object.Instantiate(transparentWallConfigs.Prefab,
                        new Vector3(targetPoint.position.x, targetPoint.position.y + y,targetPoint.position.z + z),
                        Quaternion.identity, targetPoint);
                }
            }

            return Task.CompletedTask;
        }
    }
}