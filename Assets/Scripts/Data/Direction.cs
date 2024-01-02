using UnityEngine;

namespace Assets.Scripts
{
    public static class Direction
    {
        public static Vector2 Up = new Vector2(0, 0.5f);
        public static Vector2 Down = new Vector2(0, -0.5f);
        public static Vector2 Left = new Vector2(-0.5f, 0);
        public static Vector2 Right = new Vector2(0.5f, 0);
        public static Vector3 RightRotate = new Vector3(0, 0, -90);
        public static Vector3 LeftRotate = new Vector3(0, 0, 90);
    }
}
