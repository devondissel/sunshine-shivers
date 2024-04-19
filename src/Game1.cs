using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace sunshine_shivers
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch spriteBatch;

        private bool keyEscPressed = false;

        // load texture
        Texture2D playerSprite;
        Texture2D tileGrass;
        Texture2D tileSand;
        Texture2D tileStone;
        Texture2D tileDirt;

        public static int tileSize = 36;
        public static int verticalShift = 400;
        public static int horizontalShift = 250;
        Player player = new Player();
        Dimension dimension = new Dimension();


        private bool menu_open = false;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // load texture
            playerSprite = Texture2D.FromFile(GraphicsDevice, "assets/textures/player.png");
            tileSand = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/sand.png");
            tileStone = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/stone.png");
            tileGrass = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/grass.png");
            tileDirt = Texture2D.FromFile(GraphicsDevice, "assets/textures/tiles/dirt.png");


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
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                //Exit();
                

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                if (keyEscPressed == false) {
                    if (menu_open == false) {
                        menu_open = true;
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

            // TODO: Add your drawing code here
            // draw sprite
            if (menu_open == false) {
                spriteBatch.Begin();
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
                spriteBatch.End();
            } else {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                // draw menu
            }

            

            base.Draw(gameTime);
        }
    }
}
