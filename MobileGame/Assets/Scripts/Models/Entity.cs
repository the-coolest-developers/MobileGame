using UnityEngine;

namespace Models
{
    public class Entity
    {
        public GameObject GameObject { get; set; }
        public string Tag { get; set; }

        public Entity(GameObject gameObject)
        {
            GameObject = gameObject;
            Tag = gameObject.tag;
        }

        public static implicit operator Entity(GameObject gameObject)
        {
            return new Entity(gameObject);
        }
        public static implicit operator GameObject(Entity entity)
        {
            return entity.GameObject;
        }
    }
}
