using UnityEngine;

namespace Player.Configs
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "GameConfig/PlayerConfig", order = 0)]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField] public float Speed { get; private set; }
    }
}