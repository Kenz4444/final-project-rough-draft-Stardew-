using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Net.Http;

namespace final_project_rough_draft__Stardew_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        Texture2D livingRoomTexture, bedRoomTexture, pianoRoomTexture, ghostRightTexture, ghostLeftTexture, ghostTexture, introTexture, guitarBoyTexture, ghostHuntersTexture;


        Rectangle window, livingRoomDoor, bedRoomDoor, pianoRoomDoor, ghostLocation, underBedRect, tvRect, pianoRect, bookRect, tvScreenRect, presentrect;
        MouseState mouseState;


        Vector2 ghostSpeed;
        KeyboardState keyboardState;


        List<Rectangle> barriersLiving;
        List<Rectangle> barriersBed;
        List<Rectangle> barriersPiano;
        enum Screen
        {
            Intro,
            livingRoom,
            hintOne,
            bedRoom,
            pianoRoom,
            End
        }
        Screen screen;

        bool alive;
        bool tvOn;

        SpriteFont introFont;



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
            ghostSpeed = Vector2.Zero;

            livingRoomDoor = new Rectangle(146, 526, 152, 105);
            bedRoomDoor = new Rectangle(292, 548, 222, 105);
            pianoRoomDoor = new Rectangle(740, 245, 461, 440);
            
            underBedRect = new Rectangle(339, 134, 135, 116);
            tvRect = new Rectangle(60, 150, 112, 84);
            tvScreenRect = new Rectangle(68, 175, 94, 49);
            presentrect = new Rectangle(256, 351, 76, 53);



            ghostLocation = new Rectangle(180, 450, 70, 70);




            barriersLiving = new List<Rectangle>();
            barriersLiving.Add(new Rectangle(0,0,40,window.Height));
            barriersLiving.Add(new Rectangle(window.Width-40,0,40,window.Height));
            barriersLiving.Add(new Rectangle(0, 0, 180, 110));
            barriersLiving.Add(new Rectangle(0,0,window.Width,175));
            barriersLiving.Add(new Rectangle(475,270,300,20));
            barriersLiving.Add(new Rectangle(625, 370,200, window.Height-30));
            barriersLiving.Add(new Rectangle(262, 530, 544, 68));
            barriersLiving.Add(new Rectangle(164, 523, 5, 11));
            barriersLiving.Add(new Rectangle(-17, 526, 195, 90));


            barriersBed = new List<Rectangle>();
            barriersBed.Add(new Rectangle(545,375,910,1075));
            barriersBed.Add(new Rectangle(2, 116, 230,105 ));
            barriersBed.Add(new Rectangle(335, 3, 130, 240));
            barriersBed.Add(new Rectangle(625, 60, 80, 230));
            barriersBed.Add(new Rectangle(0, 375, 66, 70)); //
            barriersBed.Add(new Rectangle(513, 484, 333, 123));
            barriersBed.Add(new Rectangle(456, 547, 58, 59));
            barriersBed.Add(new Rectangle(291, 554, 55, 42));
            barriersBed.Add(new Rectangle(-11, 482, 304, 120));
            barriersBed.Add(new Rectangle(3, 4, 805, 111));
            barriersBed.Add(new Rectangle(703, 114, 100, 129));
            barriersBed.Add(new Rectangle(-11, 274, 27, 96));
            barriersBed.Add(new Rectangle(779, 290, 16, 89));

            barriersPiano = new List<Rectangle>();
            barriersPiano.Add(new Rectangle(372, 441, 274, 112));
            barriersPiano.Add(new Rectangle(37, 482, 165, 34));
            barriersPiano.Add(new Rectangle(15, 224, 242, 142));
            barriersPiano.Add(new Rectangle(250, 97, 4, 2));
            barriersPiano.Add(new Rectangle(234, 1, 553, 134));
            barriersPiano.Add(new Rectangle(313, 136, 112, 66));
            barriersPiano.Add(new Rectangle(762, 405, 36, 202));
            barriersPiano.Add(new Rectangle(765, 128, 43, 126));
            barriersPiano.Add(new Rectangle(5, 360, 34, 234));
            barriersPiano.Add(new Rectangle(36, 571, 729, 40));
            barriersPiano.Add(new Rectangle(221, 121, 33, 107));


            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            screen = Screen.Intro;
            alive = false;
            tvOn = false;


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
            introTexture = Content.Load<Texture2D>("introscreen");
            guitarBoyTexture = Content.Load<Texture2D>("guitarBoy");
            ghostHuntersTexture = Content.Load<Texture2D>("ghostHunters");

            introFont = Content.Load<SpriteFont>("introFont");

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

            if (alive == true)
            {
                ghostTexture = guitarBoyTexture;
            }
            

            



            if (screen == Screen.Intro && keyboardState.IsKeyDown(Keys.Enter))
            {
                screen = Screen.livingRoom;
            }





            if (screen == Screen.livingRoom)
            {


                foreach (Rectangle barrier in barriersLiving)
                    if (ghostLocation.Intersects(barrier))
                        ghostLocation.Offset(-ghostSpeed);


                if (livingRoomDoor.Contains(ghostLocation))
                {
                    screen = Screen.bedRoom;
                    ghostLocation = new Rectangle(380, 476, 70, 70);

                }
                if (mouseState.LeftButton == ButtonState.Pressed && tvRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, tvRect.Width, tvRect.Height)))
                {
                    tvOn = true;
                }
                if (mouseState.RightButton == ButtonState.Pressed && tvRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, tvRect.Width, tvRect.Height)))
                {
                    tvOn = false;
                }
                if (mouseState.LeftButton == ButtonState.Pressed && presentrect.Intersects(new Rectangle(mouseState.X, mouseState.Y, presentrect.Width, presentrect.Height)))
                {
                    screen = Screen.hintOne;
                }





            }

            else if (screen == Screen.pianoRoom)
            {

                foreach (Rectangle barrier in barriersPiano)
                    if (ghostLocation.Intersects(barrier))
                        ghostLocation.Offset(-ghostSpeed);


                if (pianoRoomDoor.Contains(ghostLocation))
                {
                    screen = Screen.livingRoom;

                   ghostLocation = new Rectangle(180, 450, 70, 70);



                }
                
            }
            else if (screen == Screen.bedRoom)
            {

                foreach (Rectangle barrier in barriersBed)
                    if (ghostLocation.Intersects(barrier))
                        ghostLocation.Offset(-ghostSpeed);


                if (bedRoomDoor.Contains(ghostLocation)) 
                {
                    screen = Screen.pianoRoom;
                    ghostLocation = new Rectangle(700, 280, 70, 70);


                }
                if (mouseState.LeftButton == ButtonState.Pressed && underBedRect.Intersects(new Rectangle(mouseState.X, mouseState.Y, underBedRect.Width, underBedRect.Height)))
                {
                    alive = true;

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
                if (tvOn == true)
                {
                    _spriteBatch.Draw(ghostHuntersTexture, tvScreenRect, Color.White);
                }
                if (alive)
                {
                    _spriteBatch.Draw(guitarBoyTexture, ghostLocation, Color.White);

                }
                else
                    _spriteBatch.Draw(ghostTexture, ghostLocation, Color.White * 0.5f);


                


            }

            else if (screen == Screen.bedRoom)
            {
                _spriteBatch.Draw(bedRoomTexture, window, Color.White);
                if (alive)
                {
                    _spriteBatch.Draw(guitarBoyTexture, ghostLocation, Color.White);

                }
                else
                    _spriteBatch.Draw(ghostTexture, ghostLocation, Color.White * 0.5f);


            }
            else if (screen == Screen.pianoRoom)
            {


                _spriteBatch.Draw(pianoRoomTexture, window, Color.White);
                if (alive)
                {
                    _spriteBatch.Draw(guitarBoyTexture, ghostLocation, Color.White);

                }
                else
                    _spriteBatch.Draw(ghostTexture, ghostLocation, Color.White * 0.5f);

            }
            else if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introTexture, window, Color.White);
                _spriteBatch.DrawString(introFont, "The Afterlife Detective", new Vector2(200, 120), Color.Green);

            }



            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
