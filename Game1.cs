using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace final_project_rough_draft__Stardew_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D livingRoomTexture, bedRoomTexture, pianoRoomTexture, ghostrightTexture;


        Rectangle window, livingRoomDoor, bedRoomDoor, pianoRoomDoor, ghostrightRect, ghostrectLivingRoom, ghostrectPianoRoom, ghostrectBedRoom, ghostLocation;
        MouseState mouseState;
        Vector2 cursorPosition;
        SpriteEffects ghostEffect;

        Vector2 ghostSpeed;
        KeyboardState keyboardState;


        enum Screen
        {
            Intro,
            livingRoom,
            bedRoom,
            pianoRoom,
            End
        }
        Screen screen;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            ghostEffect = SpriteEffects.FlipHorizontally;
            window = new Rectangle(0, 0, 800, 600);
            livingRoomDoor = new Rectangle(216, 542, 253, 264);
            bedRoomDoor = new Rectangle(397, 536, 1065, 909);
            pianoRoomDoor = new Rectangle(764, 319, 461, 440);
            
            ghostrectLivingRoom = new Rectangle(190,488, 70,70);
            ghostrectPianoRoom = new Rectangle(700,280, 70, 70);
            ghostrectBedRoom = new Rectangle(380, 476, 70, 70);
            ghostLocation = new Rectangle(190, 488, 70, 70);


            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.livingRoom;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            livingRoomTexture = Content.Load<Texture2D>("livingRoom2");
            bedRoomTexture = Content.Load<Texture2D>("bedRoom2");
            pianoRoomTexture = Content.Load<Texture2D>("pianoRoom2");
            ghostrightTexture = Content.Load<Texture2D>("ghostRight");
            


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.Window.Title = mouseState.Position.ToString();
            
            cursorPosition = new Vector2(mouseState.X, mouseState.Y);
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            ghostSpeed = new Vector2();









            if (screen == Screen.livingRoom)
            {

                if   (livingRoomDoor.Contains(ghostrectLivingRoom))
                {
                    screen = Screen.bedRoom;


                }
                if (mouseState.LeftButton == ButtonState.Pressed && livingRoomDoor.Contains(mouseState.Position))
                {
                    screen = Screen.pianoRoom;
                    


                }



            }

            else if (screen == Screen.pianoRoom)
            {

                
                if (mouseState.RightButton == ButtonState.Pressed && pianoRoomDoor.Contains(mouseState.Position))
                {
                    screen = Screen.bedRoom;


                }
                if (mouseState.LeftButton == ButtonState.Pressed && pianoRoomDoor.Contains(mouseState.Position))
                {
                    screen = Screen.livingRoom;


                }
            }
            else if (screen == Screen.bedRoom)
            {
                if (mouseState.LeftButton == ButtonState.Pressed && bedRoomDoor.Contains(mouseState.Position))
                {
                    screen = Screen.pianoRoom;


                }
                if (mouseState.RightButton == ButtonState.Pressed && bedRoomDoor.Contains(mouseState.Position))
                {
                    screen = Screen.livingRoom;


                }
            }

                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here


            _spriteBatch.Begin();   

            
            if (screen == Screen.livingRoom)
            {
                
                _spriteBatch.Draw(livingRoomTexture, window, Color.White);
                _spriteBatch.Draw (ghostrightTexture,ghostrectLivingRoom, Color.White); 
                
            }

            else if (screen == Screen.bedRoom)
            {
                _spriteBatch.Draw(bedRoomTexture, window, Color.White);
                _spriteBatch.Draw(ghostrightTexture, ghostrectBedRoom, Color.White);

            }
            else if (screen == Screen.pianoRoom)
            {


                _spriteBatch.Draw(pianoRoomTexture, window, Color.White);
                _spriteBatch.Draw(ghostrightTexture, ghostrectPianoRoom, Color.White);

            }



                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
