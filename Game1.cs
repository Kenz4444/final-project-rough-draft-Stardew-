using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace final_project_rough_draft__Stardew_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D livingRoomTexture, bedRoomTexture, pianoRoomTexture;
        Rectangle window;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            livingRoomTexture = Content.Load<Texture2D>("livingRoom2");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here


            _spriteBatch.Begin();   

            _spriteBatch.Draw(livingRoomTexture, window, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
