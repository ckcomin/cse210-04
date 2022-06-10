using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Unit04.Game.Casting;
using Unit04.Game.Directing;
using Unit04.Game.Services;


namespace Unit04
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        private static int FRAME_RATE = 12;
        private static int MAX_X = 900;
        private static int MAX_Y = 600;
        private static int CELL_SIZE = 15;
        private static int FONT_SIZE = 15;
        private static int COLS = 60;
        private static int ROWS = 40;
        private static string CAPTION = "Greed";
        // private static string DATA_PATH = "Data/messages.txt";
        private static Color WHITE = new Color(255, 255, 255);
        //private static int DEFAULT_ARTIFACTS = 40;
        private static int DEFAULT_GEMS = 40;
        private static int DEFAULT_ROCKS = 40;

        private int TOTAL_SCORE = 0;


        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
        //     // create the cast
            Cast cast = new Cast();

        //     // create the banner (This can be the score)
            Actor banner = new Actor();
            banner.SetText("");
            banner.SetFontSize(FONT_SIZE);
            banner.SetColor(WHITE);
            banner.SetPosition(new Point(CELL_SIZE, 0));
            cast.AddActor("banner", banner);

        //     // create the player (Keep this)
            Actor player = new Actor();
            player.SetText("#"); 
            player.SetFontSize(FONT_SIZE);
            player.SetColor(WHITE);
            player.SetPosition(new Point(MAX_X / 2, MAX_Y / 2));
            cast.AddActor("player", player);

             // create the artifacts
             Random random = new Random(); 
             for (int i = 0; i < DEFAULT_GEMS; i++)
             {
                 string text = "*";

                 //int x = random.Next(1, COLS);
                //int y = random.Next(1, ROWS);
                 //Point position = new Point(x, y);
                 //position = position.Scale(CELL_SIZE);

                 int r = random.Next(0, 256);
                 int g = random.Next(0, 256);
                 int b = random.Next(0, 256);
                 Color color = new Color(r, g, b);

                 gem gem = new gem();
                 gem.SetText(text);
                 gem.SetFontSize(FONT_SIZE);
                 gem.SetColor(color);
                 //artifact.SetPosition(position);
                 cast.AddActor("gems", gem);
             }

             for (int i = 0; i < DEFAULT_ROCKS; i++)
             {
                 string text = "0";

                 //int x = random.Next(1, COLS);
                //int y = random.Next(1, ROWS);
                 //Point position = new Point(x, y);
                 //position = position.Scale(CELL_SIZE);

                 int r = random.Next(0, 256);
                 int g = random.Next(0, 256);
                 int b = random.Next(0, 256);
                 Color color = new Color(r, g, b);

                 rock rock = new rock();
                 rock.SetText(text);
                 rock.SetFontSize(FONT_SIZE);
                 rock.SetColor(color);
                 //artifact.SetPosition(position);
                 cast.AddActor("rocks", rock);
             }

        //     // start the game
        //     KeyboardService keyboardService = new KeyboardService(CELL_SIZE);
        //     VideoService videoService 
        //         = new VideoService(CAPTION, MAX_X, MAX_Y, CELL_SIZE, FRAME_RATE, false);
        //     Director director = new Director(keyboardService, videoService);
        //     director.StartGame(cast);
        }
    }
}