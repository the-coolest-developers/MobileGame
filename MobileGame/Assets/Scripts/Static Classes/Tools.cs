using Unity.Mathematics;
using UnityEngine;

namespace Singletones
{
    public static class Tools
    {
        public static float GetRbX(GameObject gameObject)
        {
            return gameObject.GetComponent<Rigidbody2D>().transform.position.x;
        }

        public static float GetHorizontalDistance(GameObject firstObject, GameObject secondObject)
        {
            var xa = GetRbX(firstObject);
            var xb = GetRbX(secondObject);

            return xa - xb;
        }
        public static float GetHorizontalAbsoluteDistance(GameObject firstObject, GameObject secondObject)
        {
            return math.abs(GetHorizontalDistance(firstObject, secondObject));
        }

        public static void FlipGameObject(GameObject gameObject)
        {
            gameObject.GetComponent<Rigidbody2D>().transform.Rotate(0f, 180f, 0f);
        }
    }
}
