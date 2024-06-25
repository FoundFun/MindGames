using Player.Scripts;
using UnityEngine;

namespace Wall.Scripts
{
    [CreateAssetMenu(fileName = "WallConfig", menuName = "GameConfig/WallConfig", order = 0)]
    public class WallConfig : ScriptableObject
    {
        [field: SerializeField] public TakeObject Prefab { get; private set; }
        [field: SerializeField] public ColorTag Color { get; private set; }
    }
}