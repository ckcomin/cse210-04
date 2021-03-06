using System.Collections.Generic;
using Unit04.Game.Casting;
using Unit04.Game.Services;
// make the score 

namespace Unit04.Game.Directing
{
    /// <summary>
    /// <para>A person who directs the game.</para>
    /// <para>
    /// The responsibility of a Director is to control the sequence of play.
    /// </para>
    /// </summary>
    public class Director
    {
        private KeyboardService keyboardService = null;
        private VideoService videoService = null;

        /// <summary>
        /// Constructs a new instance of Director using the given KeyboardService and VideoService.
        /// </summary>
        /// <param name="keyboardService">The given KeyboardService.</param>
        /// <param name="videoService">The given VideoService.</param>
        public Director(KeyboardService keyboardService, VideoService videoService)
        {
            this.keyboardService = keyboardService;
            this.videoService = videoService;
        }

        /// <summary>
        /// Starts the game by running the main game loop for the given cast.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void StartGame(Cast cast)
        {
            videoService.OpenWindow();
            while (videoService.IsWindowOpen())
            {
                GetInputs(cast);
                DoUpdates(cast);
                DoOutputs(cast);
            }
            videoService.CloseWindow();
        }

        /// <summary>
        /// Gets directional input from the keyboard and applies it to the robot.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        private void GetInputs(Cast cast)
        {
            Actor player = cast.GetFirstActor("player"); /* replace robot with player*/
            Point velocity = keyboardService.GetDirection();
            player.SetVelocity(velocity);
        }

        /// <summary>
        /// Updates the robot's position and resolves any collisions with artifacts.
        /// </summary>
        /// <param name="cast">The given cast.</param>

        private void DoUpdates(Cast cast)
        {
            Actor banner = cast.GetFirstActor("banner");
            Actor player = cast.GetFirstActor("player");
            List<Actor> gems = cast.GetActors("gems");
            List<Actor> rocks = cast.GetActors("rocks");

            banner.SetText("");
            int maxX = videoService.GetWidth();
            int maxY = videoService.GetHeight();
            player.MoveNext(maxX, maxY);

            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                string text = ((char)random.Next(33, 34)).ToString();
                string message = score;

                int x = random.Next(1, Program.COLS);
                int y = random.Next(1, Program.ROWS);
                Point position = new Point(x, y);
                position = position.Scale(Program.CELL_SIZE);

                int r = random.Next(0, 256);
                int g = random.Next(0, 256);
                int b = random.Next(0, 256);
                Color color = new Color(r, g, b);

                Rock rock = new Rock();
                rock.SetText(text);
                rock.SetFontSize(Program.FONT_SIZE);
                rock.SetColor(color);
                rock.SetPosition(position);
                rock.SetMessage(message);
                cast.AddActor("artifacts", rock);
            }

            // update the score
            foreach (Actor actor in gems)
            {
                if (player.GetPosition().Equals(actor.GetPosition()))
                {
                        // Artifact artifact = (Artifact) actor;
                        // string message = artifact.GetMessage();
                        // banner.SetText(message);
                    //This is where we will be updating score
                    //and deleting gem?
                }
            }

            foreach (Actor actor in rocks)
            {
                if (player.GetPosition().Equals(actor.GetPosition()))
                {
                        // Artifact artifact = (Artifact) actor;
                        // string message = artifact.GetMessage();
                        // banner.SetText(message);
                    //This is where we will be updating score
                    //and deleting rock?
                }
            } 
        }

        /// <summary>
        /// Draws the actors on the screen.
        /// </summary>
        /// <param name="cast">The given cast.</param>
        public void DoOutputs(Cast cast)
        {
            List<Actor> actors = cast.GetAllActors();
            videoService.ClearBuffer();
            videoService.DrawActors(actors);
            videoService.FlushBuffer();
        }

    }
}