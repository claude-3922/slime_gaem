using System.Numerics;
using Raylib_cs;

namespace game
{
    static class Program
    {
        static int ballsPicked = 0;
        public static void Main()
        {
            Raylib.InitWindow(800, 480, "game");
            Raylib.SetTargetFPS(30);

            //Loading images, creating instances and unloading the images
            Image slimeImage = Raylib.LoadImage("assets/slime.png");
            Image ballImage = Raylib.LoadImage("assets/food.png");
            Player player = new Player(slimeImage);
            Ball ball = new Ball(ballImage);
            Raylib.UnloadImage(slimeImage);
            Raylib.UnloadImage(ballImage);


            while (!Raylib.WindowShouldClose())
            {

                if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                {
                    player.SetPos(((int)(player.GetPos().X) + (2 * player.GetSpeed())), (int)player.GetPos().Y);
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                {
                    player.SetPos(((int)(player.GetPos().X) - (2 * player.GetSpeed())), (int)player.GetPos().Y);
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                {
                    player.SetPos((int)player.GetPos().X, ((int)(player.GetPos().Y) - (2 * player.GetSpeed())));
                }
                else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                {
                    player.SetPos((int)player.GetPos().X, ((int)(player.GetPos().Y) + (2 * player.GetSpeed())));
                }


                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                if (ballsPicked != 10)
                {
                    //We're gonna draw the player on every frame for now
                    Raylib.DrawTexture(player.GetTex(), (int)player.GetPos().X, (int)player.GetPos().Y, Color.WHITE);

                    //Collider rectangles
                    Rectangle playerCollider = new Rectangle(player.GetPos().X, player.GetPos().Y, player.GetTex().width, player.GetTex().height);
                    Rectangle ballCollider = new Rectangle(ball.GetPos().X, ball.GetPos().Y, ball.GetTex().width, ball.GetTex().height);

                    if (!Raylib.CheckCollisionRecs(playerCollider, ballCollider) && (ball.IsPickedUp() == false))
                    {
                        Raylib.DrawTexture(ball.GetTex(), (int)ball.GetPos().X, (int)ball.GetPos().Y, Color.WHITE);
                        Raylib.DrawText("No Collision Yet", 650, 0, 15, Color.BLACK);
                    }
                    else if (Raylib.CheckCollisionRecs(playerCollider, ballCollider))
                    {
                        Raylib.DrawText("Collided", 650, 20, 15, Color.BLACK);
                        ball.Ball_Is_Picked(true);
                        ballsPicked++;
                        ball.SetPos(GetRandomInt(550), GetRandomInt(400));
                        Raylib.DrawTexture(ball.GetTex(), (int)ball.GetPos().X, (int)ball.GetPos().Y, Color.WHITE);
                        ball.Ball_Is_Picked(false);
                    }
                    Raylib.DrawText("Balls Eaten: "+ ballsPicked, 0, 0, 15, Color.BLACK);
                } else {
                    Raylib.DrawText("Mr. Slime can't eat anymore :(", 150, (480/2)-30, 30, Color.BLACK);
                }
                Raylib.EndDrawing();
            }

            //Unloading textures
            player.UnloadTex();
            ball.UnloadTex();

            Raylib.CloseWindow();

        }

        private static int GetRandomInt(int bound)
        {
            Random rand = new Random();
            return rand.Next(bound);
        }

    }
}