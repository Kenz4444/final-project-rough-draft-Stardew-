using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace final_project_rough_draft__Stardew_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D livingRoomTexture, bedRoomTexture, pianoRoomTexture, ghostRightTexture, ghostLeftTexture, ghostTexture;


        Rectangle window, livingRoomDoor, bedRoomDoor, pianoRoomDoor, ghostLocation;
        MouseState mouseState;

        SpriteEffects ghostEffect;

        Vector2 ghostSpeed;
        KeyboardState keyboardState;


        List<Rectangle> barriers;


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
            //ghostEffect = SpriteEffects.FlipHorizontally;
            window = new Rectangle(0, 0, 800, 600);
            ghostSpeed = Vector2.Zero;

            livingRoomDoor = new Rectangle(180, 530, 253, 264);
            bedRoomDoor = new Rectangle(370, 545, 1065, 909);
            pianoRoomDoor = new Rectangle(740, 245, 461, 440);
            
            
            ghostLocation = new Rectangle(180, 450, 70, 70);

            barriers = new List<Rectangle>();
            barriers.Add(new Rectangle(0,0,40,window.Height));
            barriers.Add(new Rectangle(window.Width-40,0,40,window.Height));
            barriers.Add(new Rectangle(0, 0, 180, 110));
            barriers.Add(new Rectangle(0,0,window.Width,175));
            barriers.Add(new Rectangle(475,270,300,20));
            barriers.Add(new Rectangle(625, 370,200, window.Height-30));







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
            ghostRightTexture = Content.Load<Texture2D>("ghostRight");
            ghostLeftTexture = Content.Load<Texture2D>("ghostLeft");
            ghostTexture = Content.Load<Texture2D>("ghostRight");


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            this.Window.Title = mouseState.Position.ToString();

            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            ghostSpeed = new Vector2();


            ghostLocation.Y += (int)ghostSpeed.Y;
            ghostSpeed = Vector2.Zero;
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                ghostSpeed.Y -= 2;


            }

            if (keyboardState.IsKeyDown(Keys.Down))
            {
                ghostSpeed.Y += 2;

            }
            ghostLocation.X += (int)ghostSpeed.X;

            if (keyboardState.IsKeyDown(Keys.Right))
            {
                ghostSpeed.X += 2;
                ghostTexture = ghostRightTexture;


            }

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                ghostSpeed.X -= 2;
                ghostTexture = ghostLeftTexture;

            }


            ghostLocation.Offset(ghostSpeed);


            







            if (screen == Screen.livingRoom)
            {


                foreach (Rectangle barrier in barriers)
                    if (ghostLocation.Intersects(barrier))
                        ghostLocation.Offset(-ghostSpeed);


                if (livingRoomDoor.Contains(ghostLocation))
                {
                    screen = Screen.bedRoom;
                    ghostLocation = new Rectangle(380, 476, 70, 70);

                }
                



            }

            else if (screen == Screen.pianoRoom)
            {

                

                if (pianoRoomDoor.Contains(ghostLocation))
                {
                    screen = Screen.livingRoom;

                   ghostLocation = new Rectangle(180, 450, 70, 70);



                }
                
            }
            else if (screen == Screen.bedRoom)
            {

                
                if (bedRoomDoor.Contains(ghostLocation)) 
                {
                    screen = Screen.pianoRoom;
                    ghostLocation = new Rectangle(700, 280, 70, 70);


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
                _spriteBatch.Draw(ghostTexture, ghostLocation, Color.White*0.5f);

            }

            else if (screen == Screen.bedRoom)
            {
                _spriteBatch.Draw(bedRoomTexture, window, Color.White);
                _spriteBatch.Draw(ghostTexture, ghostLocation, Color.White*0.5f);

            }
            else if (screen == Screen.pianoRoom)
            {


                _spriteBatch.Draw(pianoRoomTexture, window, Color.White);
                _spriteBatch.Draw(ghostTexture, ghostLocation, Color.White*0.5f);

            }



                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
