using System.Numerics;
using Raylib_cs;

namespace game {
    public class Ball {
        private Texture2D tex;
        private Vector2 pos;
        private bool pickedBool;

        public Ball(Image ballImage) {
            tex = Raylib.LoadTextureFromImage(ballImage);
            pos = new Vector2(100.0f, 150.0f);
            pickedBool = false;
        }

        //Textures
        public void UnloadTex() {
            Raylib.UnloadTexture(tex);
        }
        public Texture2D GetTex() {
            return tex;
        }

        //Position
        public Vector2 GetPos() {
            return pos;
        }
        public void SetPos(int newPosX, int newPosY) {
            pos = new Vector2(newPosX, newPosY);
        }

        //Picked up?
        public bool isPickedUp() {
           return pickedBool;
        }
        public void pickUp() {
            pickedBool = true;
        }
    }
}