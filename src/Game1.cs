using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Net.NetworkInformation;

namespace sunshine_shivers
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        
        private SpriteBatch spriteBatch;

        // load texture
        Texture2D playerSprite0;
        Texture2D playerSprite1;
        Texture2D playerSprite2;
        Texture2D playerSprite3;
        Texture2D playerSprite4;
        Texture2D playerSprite5;
        Texture2D playerSprite6;
        Texture2D playerSprite7;

        Texture2D sheepSprite;

        Texture2D tileGrass;
        Texture2D tileSand;
        Texture2D tileStone;
        Texture2D tileDirt;
        Texture2D textQuit;
        Texture2D textSave;
        Texture2D textBack;

        public static int screenWidth = 800;
        public static int screenHeight = 450;
        public static int screenWidthHalf = screenWidth / 2; 
        public static int screenHeightHalf = screenHeight / 2; 
        public static int tileSize = screenWidth / 16;
        // width should be < 10 tiles from the center
        // height should be < 6 from the center
        public static float verticalShift = (screenWidth - tileSize) / 2;
        public static float horizontalShift = (screenHeight - tileSize) / 2;
        


        Player player = new();
        Camera camera = new();
        // DisplayCorner displayCorner = new DisplayCorner();
        Sheep sheep = new();
        Dimension dimension = new();




        private bool menu_open = false;
        // private int menu_selected = 1;

        private bool keyEscPressed = false;
        // private bool keyDownPressed = false;
        // private bool keyUpPressed = false;
        // private bool keyEnterPressed = false;

        // graphics related

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = screenWidth;
            graphics.PreferredBackBufferHeight = screenHeight;
            graphics.ApplyChanges();


            // load texture
            playerSprite0 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/south.png");
            playerSprite1 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/southwest.png");
            playerSprite2 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/west.png");
            playerSprite3 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/northwest.png");
            playerSprite4 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/north.png");
            playerSprite5 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/northeast.png");
            playerSprite6 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/east.png");
            playerSprite7 = Texture2D.FromFile(GraphicsDevice, "assets/textures/player/southeast.png");

            sheepSprite = Texture2D.FromFile(GraphicsDevice, "assets/textures/animals/sheep.png");

            tileSand = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/sand.png");
            tileStone = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/stone.png");
            tileGrass = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/grass.png");
            tileDirt = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/dirt.png");

            textSave = Texture2D.FromFile(GraphicsDevice, "assets/textures/text/save.png");
            textBack = Texture2D.FromFile(GraphicsDevice, "assets/textures/text/back_to_game.png");
            textQuit = Texture2D.FromFile(GraphicsDevice, "assets/textures/text/quit.png");

            // initialize world
            dimension.generateWorld();

            // start position player
            player.x = 3;
            player.y = 3;

            sheep.x = 4;
            sheep.y = 4;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
      


            //keyboard
            if (Keyboard.GetState().IsKeyDown(Keys.Escape)) {
                if (keyEscPressed == false) {
                    if (menu_open == false) {
                        menu_open = true;
                        // menu_selected = 1;
                    } else {
                        menu_open = false;
                    }
                }
                keyEscPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Escape) && keyEscPressed == true) keyEscPressed = false;
            player.updatePosition(dimension.world);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Black);

            // camera position
            camera.x = player.x;
            camera.y = player.y;

            if (menu_open == false) {
                // Start drawing tiles
                spriteBatch.Begin();
                int cornerTileX = (int)Math.Floor(camera.x) - 3;
                int cornerTileY = (int)Math.Floor(camera.y) - 3;
                for (int i = 0; i < 16; i++) for (int j = 0; j < 10; j++) {
                    // get the tile type
                    int tile = dimension.world[cornerTileX + i, cornerTileY + j];
                    int x = tileSize * (i + cornerTileX) - (int)(player.x * tileSize);
                    Rectangle renderLocation = new(x, tileSize * (j + cornerTileY), tileSize, tileSize);

                    switch (tile) {
                        case 0:
                            spriteBatch.Draw(tileSand, renderLocation, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw(tileGrass, renderLocation, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(tileDirt, renderLocation, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(tileStone, renderLocation, Color.White);
                            break;
                    }
                }
            }
                //         int x = (int)Math.Floor((tileSize * (i - player.x)));
                //         int y = (int)Math.Floor((tileSize * -(j - player.y)));
                //     Rectangle tileLocation = new Rectangle(x + verticalShift, y + horizontalShift, tileSize, tileSize);
                //     switch (dimension.world[i, j])
                //     {
                //         case 0:
                //             spriteBatch.Draw(tileSand, tileLocation, Color.White);
                //             break;
                //         case 1:
                //             spriteBatch.Draw(tileGrass, tileLocation, Color.White);
                //             break;
                //         case 2:
                //             spriteBatch.Draw(tileDirt, tileLocation, Color.White);
                //             break;
                //         case 3:
                //             spriteBatch.Draw(tileStone, tileLocation, Color.White);
                //             break;
                //     }
                // }


                // // draw player
                // Rectangle playerPosition = new Rectangle(verticalShift, horizontalShift, tileSize, tileSize);
                // switch (player.facing)
                // {
                //     case 0: spriteBatch.Draw(playerSprite0, playerPosition, Color.White); break;
                //     case 1: spriteBatch.Draw(playerSprite1, playerPosition, Color.White); break;
                //     case 2: spriteBatch.Draw(playerSprite2, playerPosition, Color.White); break;
                //     case 3: spriteBatch.Draw(playerSprite3, playerPosition, Color.White); break;
                //     case 4: spriteBatch.Draw(playerSprite4, playerPosition, Color.White); break;
                //     case 5: spriteBatch.Draw(playerSprite5, playerPosition, Color.White); break;
                //     case 6: spriteBatch.Draw(playerSprite6, playerPosition, Color.White); break;
                //     case 7: spriteBatch.Draw(playerSprite7, playerPosition, Color.White); break;
                //     default: break;
                // }


                // // draw animals
                // int sheep_x = (int)Math.Floor((tileSize * (sheep.x - player.x)));
                // int sheep_y = (int)Math.Floor((tileSize * -(sheep.y) - player.y));
                // Rectangle sheepPosition = new Rectangle(sheep_x, sheep_y, tileSize, tileSize);
                // spriteBatch.Draw(sheepSprite, sheepPosition, Color.White);


            // menu
            // else {
            //     GraphicsDevice.Clear(Color.DarkSlateGray);
            //     Rectangle menuText1 = new Rectangle(verticalShift - 200, horizontalShift - 100, 400, 50);
            //     Rectangle menuText2 = new Rectangle(verticalShift - 100, horizontalShift, 100, 50);
            //     Rectangle menuText3 = new Rectangle(verticalShift - 100, horizontalShift + 100, 100, 50);
            //     spriteBatch.Draw(textBack, menuText1, Color.White);
            //     spriteBatch.Draw(textSave, menuText2, Color.White);
            //     spriteBatch.Draw(textQuit, menuText3, Color.White);

            //     // up
            //     if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //     {
            //         if (keyUpPressed == false && menu_selected != 1) menu_selected--;
            //         keyUpPressed = true;
            //     }
            //     if (Keyboard.GetState().IsKeyUp(Keys.Up) && keyUpPressed == true)
            //     {
            //         keyUpPressed = false;
            //     }

            //     // down
            //     if (Keyboard.GetState().IsKeyDown(Keys.Down))
            //     {
            //         if (keyDownPressed == false && menu_selected != 3) menu_selected++;
            //         keyDownPressed = true;
            //     }
            //     if (Keyboard.GetState().IsKeyUp(Keys.Down) && keyDownPressed == true)
            //     {
            //         keyDownPressed = false;
            //     }

            //     switch (menu_selected) {
            //         case 1: spriteBatch.Draw(textBack, menuText1, Color.Red); break;
            //         case 2: spriteBatch.Draw(textSave, menuText2, Color.Red); break;
            //         case 3: spriteBatch.Draw(textQuit, menuText3, Color.Red); break;
            //         default: break;
            //     }
            //     // enter
            //     if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            //     {
            //         if (keyEnterPressed == false) {


            //     switch (menu_selected) {
            //         case 1: menu_open = false; break;
            //         case 2: {
            //             graphics.ToggleFullScreen();
            //             // screenWidth = GraphicsDevice.Adapter.CurrentDisplayMode.Width;
            //             // screenHeight = GraphicsDevice.Adapter.CurrentDisplayMode.Height;
            //         }; break;
            //         case 3: Exit(); break;
            //         default: break;
            //     }
            //         };
            //         keyEnterPressed = true;
            //     }
            //     if (Keyboard.GetState().IsKeyUp(Keys.Enter) && keyEnterPressed == true)
            //     {
            //         keyEnterPressed = false;
            //     }
            // }


            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
