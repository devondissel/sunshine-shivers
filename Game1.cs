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


        // load texture
        Texture2D playerSprite;
        Texture2D tileGrass;
        Texture2D tileSand;
        Texture2D tileStone;
        Texture2D tileDirt;

        public static int tileSize = 32;
        Player player = new Player();

        int[,] world = new int[20, 20];

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // load texture
            playerSprite = Texture2D.FromFile(GraphicsDevice, "../../../assets/player.png");
            tileSand = Texture2D.FromFile(GraphicsDevice, "../../../assets/tiles/sand.png");
            tileStone = Texture2D.FromFile(GraphicsDevice, "../../../assets/tiles/stone.png");
            tileGrass = Texture2D.FromFile(GraphicsDevice, "../../../assets/tiles/grass.png");
            tileDirt = Texture2D.FromFile(GraphicsDevice, "../../../assets/tiles/dirt.png");

            // initialize world
            Random rnd = new Random();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    int tile = rnd.Next(4);
                    world[i, j] = tile;
                }
            }

            // start position player
            player.positionX = 192;
            player.positionY = 192;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            // KEYPRESSES
            player.updatePosition();
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            // draw sprite

            spriteBatch.Begin();

            // draw world
            for (int i = 0; i < 20; i++) 
            {
                for (int j = 0; j < 20; j++)
                {
                    Rectangle tileLocation = new Rectangle(i * tileSize - player.positionX, j * tileSize - player.positionY, tileSize, tileSize);
                    switch (world[i, j])
                    {
                        case 0:
                            spriteBatch.Draw(tileSand, tileLocation, Color.White);
                            break;
                        case 1:
                            spriteBatch.Draw(tileDirt, tileLocation, Color.White);
                            break;
                        case 2:
                            spriteBatch.Draw(tileGrass, tileLocation, Color.White);
                            break;
                        case 3:
                            spriteBatch.Draw(tileStone, tileLocation, Color.White);
                            break;
                    }
                }
            }
            Rectangle playerPosition = new Rectangle(192, 192, tileSize, tileSize);
            spriteBatch.Draw(playerSprite, playerPosition, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
