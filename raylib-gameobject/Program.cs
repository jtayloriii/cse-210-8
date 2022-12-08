using Raylib_cs;
using System.Numerics;

namespace HelloWorld
{
    static class Program
    {
        public static void Main()
        {

            var ScreenHeight = 480;
            var ScreenWidth = 800;
            var Objects = new List<GameObject>();
            var Random = new Random();

            Raylib.InitWindow(ScreenWidth, ScreenHeight, "GameObject");
            Raylib.SetTargetFPS(40);

            while (!Raylib.WindowShouldClose())
            {
                // Add a new random object to the screen every iteration of our game loop
                var whichType = Random.Next(3);

                // Generate a random velocity for this object
                var randomY = Random.Next(-4, 4);
                var randomX = Random.Next(-4, 4);

                // Each object will start about the center of the screen
                var position = new Vector2(ScreenWidth / 2, ScreenHeight / 2);

                switch (whichType) {
                    case 0:
                        Console.WriteLine("Creating a square");
                        var square = new GameSquare(Color.BLUE, 50);
                        square.Position = position;
                        square.Velocity = new Vector2(randomX, randomY);
                        Objects.Add(square);
                        break;
                    case 1:
                        Console.WriteLine("Creating a circle");
                        var circle = new GameCircle(Color.RED, 50);
                        circle.Position = position;
                        circle.Velocity = new Vector2(randomX, randomY);
                        Objects.Add(circle);
                        break;
                    case 2:
                        Console.WriteLine("Creating some text");
                        break;
                    default:
                        break;
                }


                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                // Draw all of the objects in their current location
                foreach (var obj in Objects) {
                    obj.Draw();
                }

                Raylib.EndDrawing();

                // Move all of the objects to their next location
                foreach (var obj in Objects) {
                    obj.Move();
                }
            }

            Raylib.CloseWindow();
        }
    }
}

