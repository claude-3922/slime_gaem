using System.Numerics;
using Raylib_cs;

namespace game {
    public class Player {

        private Texture2D tex;
        private Vector2 pos;
        private int speed = 3;
        private int size = 2;

        //Constructor
        public Player(Image slimeImage) {
            tex = Raylib.LoadTextureFromImage(slimeImage);
            pos = new Vector2(800/2, 480/2);
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

        //Speed
        public int GetSpeed() {
            return speed;
        }
        public void SetSpeed(int newSpeed) {
            speed = newSpeed;
        }

        //Size
        public int GetSize() {
            return size;
        }
        public void SetSize(int newSize) {
            speed = newSize;
        }
    }
}