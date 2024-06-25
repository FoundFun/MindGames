using UnityEngine;

namespace Spawner.Scripts
{
    [CreateAssetMenu(fileName = "SpawnerWallConfig", menuName = "GameConfig/SpawnerWallConfig", order = 0)]
    public class SpawnerWallConfig : ScriptableObject
    {
        [field: SerializeField] public int Width { get; private set; } = 3;
        [field: SerializeField] public int Height { get; private set; } = 3;
    }
}