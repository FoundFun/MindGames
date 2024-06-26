using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Wall;
using Wall.Scripts;

namespace Spawner.Scripts
{
    public class SpawnerWall
    {
        private readonly SpawnerWallConfig _spawnerWallConfig;
        
        private List<WallConfig> _targetStackWalls = new List<WallConfig>();

        public SpawnerWall(SpawnerWallConfig spawnerWallConfig)
        {
            _spawnerWallConfig = spawnerWallConfig;
        }
  
        public Task<List<ColorTag>> SpawnTargetWall(List<WallConfig> wallConfigs, Transform targetPoint)
        {
            List<ColorTag> colors = new List<ColorTag>();
            
            for (int i = 0; i < _spawnerWallConfig.Height; ++i)
            {
                for (int j = 0; j < _spawnerWallConfig.Width; ++j)
                {
                    int index = Random.Range(0, wallConfigs.Count);

                    TakeObject takeObject = Object.Instantiate(wallConfigs[index].Prefab,
                        new Vector3(targetPoint.position.x, targetPoint.position.y + i,targetPoint.position.z + j),
                        Quaternion.identity, targetPoint);
                    
                    takeObject.Initialize(wallConfigs[index].Color);
                    takeObject.Freeze();
                    takeObject.IsTake(false);

                    colors.Add(takeObject.TargetColor);
                    _targetStackWalls.Add(wallConfigs[index]);
                }
            }

            return Task.FromResult(colors);
        }

        public Task SpawnStackWall(Transform targetPoint)
        {
            for (int i = 0; i < _targetStackWalls.Count; i++)
            {
                var randomPositionX = Random.Range(1, 5);
                var randomPositionZ = Random.Range(1, 5);

                TakeObject takeObject = Object.Instantiate(_targetStackWalls[i].Prefab,
                    new Vector3(targetPoint.position.x + randomPositionX, targetPoint.position.y,targetPoint.position.z + randomPositionZ),
                    Quaternion.identity, targetPoint);
                
                takeObject.Initialize(_targetStackWalls[i].Color);
            }
            
            return Task.CompletedTask;
        }

        public Task<IReadOnlyList<TransparentObject>> SpawnCurrentWall(TransparentObject transparentWallConfigs, Transform targetPoint,
            List<ColorTag> targetGameColors)
        {
            List<TransparentObject> transparentObjects = new List<TransparentObject>();

            var counter = 0;
            
            for (int i = 0; i < _spawnerWallConfig.Height; ++i)
            {
                for (int j = 0; j < _spawnerWallConfig.Width; ++j)
                {
                    TransparentObject transparentObject = Object.Instantiate(transparentWallConfigs,
                        new Vector3(targetPoint.position.x, targetPoint.position.y + i,targetPoint.position.z + j),
                        Quaternion.identity, targetPoint);

                    transparentObject.SetColor(targetGameColors[counter]);
                    transparentObjects.Add(transparentObject);
                    counter++;
                }
            }

            IReadOnlyList<TransparentObject> readOnlyList = transparentObjects;

            return Task.FromResult(readOnlyList);
        }
    }
}