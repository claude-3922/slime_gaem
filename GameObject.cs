using System.Numerics;
using Raylib_cs;

namespace slime_gaem
{
    public class GameObject
    {

        private Texture2D tex;
        private Vector2 pos;

        public GameObject(Image image, Vector2 defaultPos)
        {
            tex = Raylib.LoadTextureFromImage(image);
            pos = defaultPos;
        }

        //Textures
        public void UnloadTex()
        {
            Raylib.UnloadTexture(tex);
        }
        public Texture2D GetTex()
        {
            return tex;
        }

        //Position
        public Vector2 GetPos()
        {
            return pos;
        }
        public void SetPos(float newPosX, float newPosY)
        {
            pos = new Vector2(newPosX, newPosY);
        }
    }
}