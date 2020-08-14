using UnityEngine;
using UnityEngine.Serialization;

namespace Models.Attributes
{
    public class EntityAttributes : MonoBehaviour
    {
        [FormerlySerializedAs("BattleAttributes")]
        public BattleAttributes battleAttributes;

        [FormerlySerializedAs("MovementAttributes")]
        public MovementAttributes movementAttributes;
    }
}
