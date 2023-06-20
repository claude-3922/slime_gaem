using System.Numerics;
using Raylib_cs;

namespace slime_gaem
{
    static class Program
    {
        private static int ballsPicked = 0;
        public static void Main()
        {
            Raylib.InitWindow(800, 480, "game");
            Raylib.SetTargetFPS(30);

            //Loading images, creating instances and unloading the images
            Image slimeImage = Raylib.LoadImage("assets/slime.png");
            Image ballImage = Raylib.LoadImage("assets/food.png");
            Player player = new Player(slimeImage, new Vector2(800 / 2, 480 / 2));
            Ball ball = new Ball(ballImage, new Vector2(GetRandomInt(750), GetRandomInt(430)));
            Raylib.UnloadImage(slimeImage);
            Raylib.UnloadImage(ballImage);


            while (!Raylib.WindowShouldClose())
            {

                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    player.SetPos((player.GetPos().X + player.GetSpeed()), player.GetPos().Y);
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    player.SetPos((player.GetPos().X - player.GetSpeed()), player.GetPos().Y);
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    player.SetPos(player.GetPos().X, (player.GetPos().Y - player.GetSpeed()));
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    player.SetPos(player.GetPos().X, (player.GetPos().Y + player.GetSpeed()));
                }


                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                if (ballsPicked != 10)
                {
                    Raylib.DrawTextureEx(player.GetTex(), player.GetPos(), 0, 1 * (ballsPicked + 1), Color.WHITE);

                    //Collider rectangles
                    Rectangle playerCollider = new Rectangle(player.GetPos().X, player.GetPos().Y, (int)(player.GetTex().width * (ballsPicked + 1)), (int)(player.GetTex().height * (ballsPicked + 1)));
                    Rectangle ballCollider = new Rectangle(ball.GetPos().X, ball.GetPos().Y, (int)(ball.GetTex().width), (int)(ball.GetTex().height));

                    if (!Raylib.CheckCollisionRecs(playerCollider, ballCollider) && (ball.IsPickedUp() == false))
                    {
                        Raylib.DrawTextureEx(ball.GetTex(), ball.GetPos(), 0, 1, Color.WHITE);
                        Raylib.DrawText("No Collision Yet", 650, 0, 15, Color.BLACK);
                    }
                    else if (Raylib.CheckCollisionRecs(playerCollider, ballCollider))
                    {
                        Raylib.DrawText("Collided", 650, 20, 15, Color.BLACK);
                        ball.Ball_Is_Picked(true);
                        ballsPicked++;
                        ball.SetPos(GetRandomInt(750), GetRandomInt(430));
                        Raylib.DrawTextureEx(ball.GetTex(), ball.GetPos(), 0, 1, Color.WHITE);
                        ball.Ball_Is_Picked(false);
                    }
                    Raylib.DrawText("Balls Eaten: " + ballsPicked, 0, 0, 15, Color.BLACK);
                }
                else
                {
                    Raylib.DrawText("Mr. Slime can't eat anymore :(", 150, (480 / 2) - 30, 30, Color.BLACK);
                }
                Raylib.EndDrawing();
            }

            //Unloading textures
            player.UnloadTex();
            ball.UnloadTex();

            Raylib.CloseWindow();

        }

        private static float GetRandomInt(int bound)
        {
            Random rand = new Random();
            return (float)(rand.Next(bound));
        }

    }
}