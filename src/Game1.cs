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
        Texture2D playerSprite;
        Texture2D tileGrass;
        Texture2D tileSand;
        Texture2D tileStone;
        Texture2D tileDirt;
        Texture2D textQuit;
        Texture2D textSave;
        Texture2D textBack;

        public static int screenWidth = 1280;
        public static int screenHeight = 720;
        public static int tileSize = screenWidth >> 4;
        public static int verticalShift = (screenWidth - tileSize) >> 1;
        public static int horizontalShift = (screenHeight - tileSize) >> 1;

        Player player = new Player();
        Dimension dimension = new Dimension();




        private bool menu_open = false;
        private int menu_selected = 1;

        private bool keyEscPressed = false;
        private bool keyDownPressed = false;
        private bool keyUpPressed = false;
        private bool keyEnterPressed = false;

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
            playerSprite = Texture2D.FromFile(GraphicsDevice, "assets/textures/player.png");

            tileSand = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/sand.png");
            tileStone = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/stone.png");
            tileGrass = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/grass.png");
            tileDirt = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/dirt.png");

            textSave = Texture2D.FromFile(GraphicsDevice, "assets/textures/text/save.png");
            textBack = Texture2D.FromFile(GraphicsDevice, "assets/textures/text/back_to_game.png");
            textQuit = Texture2D.FromFile(GraphicsDevice, "assets/textures/text/quit.png");


            // playerSprite = Texture2D.FromFile(GraphicsDevice, "../../../assets/textures/player.png");
            // tileSand = Texture2D.FromFile(GraphicsDevice, "../../../assets/textures/tiles/sand.png");
            // tileStone = Texture2D.FromFile(GraphicsDevice, "../../../assets/textures/tiles/stone.png");
            // tileGrass = Texture2D.FromFile(GraphicsDevice, "../../../assets/textures/tiles/grass.png");
            // tileDirt = Texture2D.FromFile(GraphicsDevice, "../../../assets/textures/tiles/dirt.png");

            // initialize world
            dimension.generateWorld();

            // start position player
            player.positionX = 3;
            player.positionY = 3;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
      

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (keyEscPressed == false) {
                    if (menu_open == false) {
                        menu_open = true;
                        menu_selected = 1;
                    } else {
                        menu_open = false;
                    }
                }
                keyEscPressed = true;
            }
            if (Keyboard.GetState().IsKeyUp(Keys.Escape) && keyEscPressed == true)
            {
                keyEscPressed = false;
            }


            // KEYPRESSES
            player.updatePosition(dimension.world);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (menu_open == false) {
                // draw world
                for (int i = 0; i < 40; i++) 
                {
                    for (int j = 0; j < 40; j++)
                    {
                        Rectangle tileLocation = new Rectangle(tileSize * (i - player.positionX) + verticalShift, tileSize * (j - player.positionY) + horizontalShift, tileSize, tileSize);
                        switch (dimension.world[i, j])
                        {
                            case 0:
                                spriteBatch.Draw(tileSand, tileLocation, Color.White);
                                break;
                            case 1:
                                spriteBatch.Draw(tileGrass, tileLocation, Color.White);
                                break;
                            case 2:
                                spriteBatch.Draw(tileDirt, tileLocation, Color.White);
                                break;
                            case 3:
                                spriteBatch.Draw(tileStone, tileLocation, Color.White);
                                break;
                        }
                    }
                }
                Rectangle playerPosition = new Rectangle(verticalShift, horizontalShift, tileSize, tileSize);
                spriteBatch.Draw(playerSprite, playerPosition, Color.White);
            } else {
                GraphicsDevice.Clear(Color.DarkSlateGray);
                Rectangle menuText1 = new Rectangle(verticalShift - 200, horizontalShift - 100, 400, 50);
                Rectangle menuText2 = new Rectangle(verticalShift - 100, horizontalShift, 100, 50);
                Rectangle menuText3 = new Rectangle(verticalShift - 100, horizontalShift + 100, 100, 50);
                spriteBatch.Draw(textBack, menuText1, Color.White);
                spriteBatch.Draw(textSave, menuText2, Color.White);
                spriteBatch.Draw(textQuit, menuText3, Color.White);

                // up
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    if (keyUpPressed == false && menu_selected != 1) menu_selected--;
                    keyUpPressed = true;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Up) && keyUpPressed == true)
                {
                    keyUpPressed = false;
                }

                // down
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    if (keyDownPressed == false && menu_selected != 3) menu_selected++;
                    keyDownPressed = true;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Down) && keyDownPressed == true)
                {
                    keyDownPressed = false;
                }

                switch (menu_selected) {
                    case 1: spriteBatch.Draw(textBack, menuText1, Color.Red); break;
                    case 2: spriteBatch.Draw(textSave, menuText2, Color.Red); break;
                    case 3: spriteBatch.Draw(textQuit, menuText3, Color.Red); break;
                    default: break;
                }
                // enter
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    if (keyEnterPressed == false) {


                switch (menu_selected) {
                    case 1: menu_open = false; break;
                    case 2: ; break;
                    case 3: Exit(); break;
                    default: break;
                }
                    };
                    keyEnterPressed = true;
                }
                if (Keyboard.GetState().IsKeyUp(Keys.Enter) && keyEnterPressed == true)
                {
                    keyEnterPressed = false;
                }


            }

            

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
