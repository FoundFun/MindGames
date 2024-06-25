using UnityEngine;

namespace Wall.Scripts
{
    [CreateAssetMenu(fileName = "WallConfig", menuName = "GameConfig/WallConfig", order = 51)]
    public class WallConfig : ScriptableObject
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
        [field: SerializeField] public Color32 Color { get; private set; }
    }
}