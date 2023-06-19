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
            Raylib.SetTargetFPS(5);

            //Loading images, creating instances and unloading the images
            Image slimeImage = Raylib.LoadImage("assets/slime.png");
            Image ballImage = Raylib.LoadImage("assets/food.png");
            Player player = new Player(slimeImage);
            Ball ball = new Ball(ballImage);
            Raylib.UnloadImage(slimeImage);
            Raylib.UnloadImage(ballImage);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.DrawText("uwu", 100, 100, 10, Color.BEIGE);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {
                    player.SetPos(((int)(player.GetPos().X) + (2*player.GetSpeed())), (int)player.GetPos().Y);
                } else if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {
                    player.SetPos(((int)(player.GetPos().X) - (2*player.GetSpeed())), (int)player.GetPos().Y);
                } else if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) {
                    player.SetPos((int)player.GetPos().X, ((int)(player.GetPos().Y) - (2*player.GetSpeed())));
                } else if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) {
                    player.SetPos((int)player.GetPos().X, ((int)(player.GetPos().Y) + (2*player.GetSpeed())));
                }

                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                
                //We're gonna draw the player on every frame for now
                Raylib.DrawTexture(player.GetTex(), (int)player.GetPos().X, (int)player.GetPos().Y, Color.WHITE);

                //Collider rectangles
                Rectangle playerCollider = new Rectangle(player.GetPos().X, player.GetPos().Y, player.GetTex().width, player.GetTex().height);
                Rectangle ballCollider = new Rectangle(ball.GetPos().X, ball.GetPos().Y, ball.GetTex().width, ball.GetTex().height);
                
                if (!Raylib.CheckCollisionRecs(playerCollider, ballCollider) && (ball.isPickedUp() == false)) {
                    Raylib.DrawTexture(ball.GetTex(), (int)ball.GetPos().X, (int)ball.GetPos().Y, Color.WHITE);
                    //Raylib.DrawRectangle(100, 100, 10, 10, Color.BLACK);
                    Console.WriteLine("No collision yet");
                } else if (Raylib.CheckCollisionRecs(playerCollider, ballCollider)){
                    Console.WriteLine("Collided");
                    ball.pickUp();
                    ballsPicked++;
                    ball.SetPos(GetRandomInt(550), GetRandomInt(400));
                    Raylib.DrawTexture(ball.GetTex(), (int)ball.GetPos().X, (int)ball.GetPos().Y, Color.WHITE);
                }
                Console.WriteLine("Balls eaten: " + ballsPicked);
                
            }

            //Unloading textures
            player.UnloadTex();
            ball.UnloadTex();

            Raylib.CloseWindow();
            
        }

        private static int GetRandomInt(int bound) {
            Random rand = new Random();
            return rand.Next(bound);
        }
    }
}