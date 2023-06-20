using System.Numerics;
using Raylib_cs;

namespace game {
    public class Player : GameObject {
        private float speed = 6.0f;

        //Constructor
        public Player(Image slimeImage, Vector2 defaultPos) : base (slimeImage, defaultPos){}

        //Speed
        public float GetSpeed() {
            return speed;
        }
        public void SetSpeed(float newSpeed) {
            speed = newSpeed;
        }
    }
}