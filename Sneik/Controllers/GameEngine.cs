using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Sneik.Controllers.Input;
using Sneik.Controllers.Input.Devices;
using Sneik.Enumerations;
using Sneik.Models;
using Sneik.Models.Screen;
using Sneik.Utils;
using Sneik.Views;

namespace Sneik.Controllers
{
    public class GameEngine
    {
        private const int FrameDelayMilliseconds = 100;

        private InputManager InputManager { get; set; }
        private RenderingEngine RenderingEngine { get; set; }

        private GameScreen GameScreen { get; set; }
        public GameState GameState { get; set; }
        private Stopwatch GameTimer { get; set; }

        // Game objects
        private Snake Snake { get; set; }
        private Apple Apple { get; set; }

        // Views
        private SnakeView SnakeView { get; set; }
        private AppleView AppleView { get; set; }

        /// <summary>
        /// Sets up the game engine
        /// </summary>
        public GameEngine()
        {
            Initialize();
            LoadContent();
        }

        /// <summary>
        /// Starts the game and game-loop
        /// </summary>
        public void StartGame()
        {
            GameState = GameState.Playing;

            GameTimer.Start();

            while (GameState != GameState.GameOver)
            {
                GameLoop();
            }
        }

        /// <summary>
        /// Initializes input manager, rendering engine, game object and so on.
        /// </summary>
        private void Initialize()
        {
            GameScreen = new ConsoleGameScreen();

            InputManager = new InputManager();
            InputManager.AddInputDevice(new KeyboardInputDevice());

            Snake = new Snake(Direction.Down, new []{new Coord(10,10), new Coord(10,11), new Coord(10,12)});
            SnakeView = new SnakeView(Snake);

            Apple = Apple.Create(GenerateRandomCoordinate(Snake.Body));
            AppleView = new AppleView(Apple);

            RenderingEngine = new RenderingEngine();
            RenderingEngine.AddView(AppleView);
            RenderingEngine.AddView(SnakeView);
            

            GameTimer = new Stopwatch();
        }

        /// <summary>
        /// Loads all external resources (gfx, sounds, etc..) here
        /// 
        /// Empty at the moment.
        /// </summary>
        private void LoadContent()
        {
            
        }

        /// <summary>
        /// The game loop. Takes care of running at the desired frame rate
        /// and calls the Update- and Draw-methods.
        /// </summary>
        private void GameLoop()
        {
            if (GameTimer.ElapsedMilliseconds < FrameDelayMilliseconds) return;

            GameTimer.Restart();

            Update();
            Draw();
        }

        /// <summary>
        /// All game logic happens here. Input handling, Collision detection
        /// and updating game objects
        /// </summary>
        private void Update()
        {
            // Checks for input
            CheckInput();

            // If we're not playing, then why bother continuing?
            if (GameState != GameState.Playing)
                return;

            // If all goes accordingly, we move our snake!
            Snake.Move();

            // Collision Detection
            CheckCollisions();

            
        }

        /// <summary>
        /// Responsible for drawing all components
        /// </summary>
        private void Draw()
        {
            if (GameState != GameState.Playing) return;

            RenderingEngine.Draw();
        }

        /// <summary>
        /// Checks devices for input and acts accordingly
        /// </summary>
        private void CheckInput()
        {
            // Checks the keyboard for any input
            if (InputManager.IsInputAvailable<KeyboardInputDevice>())
            {
                var key = (ConsoleKeyInfo)InputManager.GetInput<KeyboardInputDevice>();

                if (key.Key == ConsoleKey.Spacebar)
                {
                    GameState = (GameState != GameState.Paused) ? GameState.Paused : GameState.Playing;
                }

                if (key.Key == ConsoleKey.Escape)
                {
                    GameState = GameState.GameOver;
                    return;
                }

                switch (key.Key)
                {
                    case ConsoleKey.RightArrow:
                        Snake.ChangeDirection(Direction.Right);
                        break;
                    case ConsoleKey.LeftArrow:
                        Snake.ChangeDirection(Direction.Left);
                        break;
                    case ConsoleKey.UpArrow:
                        Snake.ChangeDirection(Direction.Up);
                        break;
                    case ConsoleKey.DownArrow:
                        Snake.ChangeDirection(Direction.Down);
                        break;
                }

            }
        }

        /// <summary>
        /// Checks if our game objects collide with each other, themselves
        /// or the screen
        /// </summary>
        private void CheckCollisions()
        {
            // Checks if the snake has crashed with the boundaries of the board
            if (CollisionDetector.DetectBoundaries(Snake.Head, GameScreen))
            {
                GameState = GameState.GameOver;
            }

            // Checks to see if Snake has collided with the 'ol clumsy self!
            if (CollisionDetector.Detect(
                Snake.BodyWithoutHead, Snake.Head))
            {
                GameState = GameState.GameOver;
            }

            // Checks to see if the Snake has eaten an apple! Yum yum.
            if (CollisionDetector.Detect(Snake.Head, Apple.Position))
            {
                Snake.Grow();
                Apple = Apple.Create(GenerateRandomCoordinate(Snake.Body));

                // Update the apple view with our new Apple!
                AppleView.UpdateView(Apple);
            }
        }

        /// <summary>
        /// Helper method for creating a random coordinate that
        /// doesn't collide with any objects
        /// </summary>
        /// <param name="coordsNotToCollideWith">List of coordinates to avoid</param>
        /// <returns>New coordinate</returns>
        private Coord GenerateRandomCoordinate(IList<Coord> coordsNotToCollideWith)
        {
            return GenerateRandomCoordinate(GameScreen, coordsNotToCollideWith);
        }

        /// <summary>
        /// Generic method for creating a random coordinate that doesn't collide with
        /// specified coordinates and a game screen. 
        /// </summary>
        /// <param name="screen">Object representing the bounds of the display</param>
        /// <param name="coordsNotToCollideWith">List of coordinates to avoid</param>
        /// <returns></returns>
        public static Coord GenerateRandomCoordinate(GameScreen screen, IList<Coord> coordsNotToCollideWith)
        {
            var coord = Coord.GenerateRandomCoord(screen.Width, screen.Height);

            while (CollisionDetector.Detect(coordsNotToCollideWith, coord)
                && CollisionDetector.DetectBoundaries(coord, screen))
            {
                coord = Coord.GenerateRandomCoord(screen.Width, screen.Height);
            }

            return coord;
        }
    }
}
