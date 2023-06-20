using System.Numerics;
using Raylib_cs;

namespace slime_gaem
{
    public class Ball : GameObject
    {
        private bool pickedBool;

        public Ball(Image ballImage, Vector2 defaultPos) : base(ballImage, defaultPos)
        {
            pickedBool = false;
        }

        //Picked up?
        public bool IsPickedUp()
        {
            return pickedBool;
        }
        public void Ball_Is_Picked(bool state)
        {
            pickedBool = state;
        }
    }
}