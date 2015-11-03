using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;

namespace Game4
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
        
    {
    
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // To make the ball spin
        float Spin;

         // Create a lives counter
        int Lives;

        // Create a score counter
        int Score;

        // Used to check how many levels have been cleared
        int Level;

        // Used for the Spritefont
        SpriteFont Display;

        // Create a boolean flag for signalling the game ending
        bool GameEnding;

        // Create an integer representing the amount of time the game ended in milliseconds
        double TimeGameEnded;

        // Creates an integer that represents when we should close the game in milliseconds
        const double CloseGameTime = 5000.0;

        //This allows the background to be drawn and its position to be changed
        Texture2D Background;
        Vector2 Backgroundposition;

        // This allows the ball to be drawn and its position to be changed
        Texture2D Ball;
        Vector2 ballposition;

        // This allows the first list of blocks to be drawn and its position to be changed
        List<Block> blocks = new List<Block>();

        // This allows the first paddle to be drawn and its position to be changed
        Texture2D Paddle;
        Vector2 paddleposition;

        // To set the ball's speed
        Vector2 ballspeed;

        //To set the paddle's speed
        Vector2 paddlespeed;
        
        // Used for the background music variable
        protected Song song;
        protected SpriteFont font;

        // Used for the explosion sound variable
        private SoundEffect Explosion1;



        public Game1()
          
        {
            graphics = new GraphicsDeviceManager(this) {
            PreferredBackBufferHeight=600, PreferredBackBufferWidth = 800};
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            // Initial ball speed set
            ballspeed = new Vector2(01.0f, 5.0f);

            //Initial paddle speed set 
            paddlespeed = new Vector2(05.0f, 0.0f);

            // Set the initial amount of lives
            Lives = 3;

            // Set the intitial amount of levels cleared
            Level = 0;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            // Allows for the sprites and background to be drawn and moved
            Background = Content.Load<Texture2D>("Background 1");
            Backgroundposition = new Vector2(0.0f, 0.0f);

            Ball = Content.Load<Texture2D>("Ball Sprite");
            ballposition = new Vector2(400.0f, 300.0f);

            Paddle = Content.Load<Texture2D>("Paddle Sprite");
            paddleposition = new Vector2(300.0f, 545.0f);

            // Everything for the blocks first batch
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 200, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 280, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 320, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 200, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 240, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 280, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 320, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 200, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 240, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 280, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 320, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 200, 110));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 240, 110));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 110));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 320, 110));

            // Everything for the blocks Second batch
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 200, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 280, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 320, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 200, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 240, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 280, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 320, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 200, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 240, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 280, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 320, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 200, 370));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 240, 370));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 370));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 320, 370));

            // Everything for the blocks Third batch
            blocks.Add(new Block( Content.Load<Texture2D> ("Block7"),480, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 520, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 560, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 600, 50));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 480, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 520, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 560, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 600, 70));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 480, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 520, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 560, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 600, 90));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 480, 110));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 520, 110));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 560, 110));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 600, 110));

            // Everything for the blocks Fourth batch
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 480, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 520, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 560, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 600, 310));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 480, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 520, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 560, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 600, 330));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 480, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 520, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 560, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 600, 350));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 480, 370));
            blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 520, 370));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 560, 370));
            blocks.Add(new Block(Content.Load<Texture2D>("Block7"), 600, 370));

            //Used for playing the background music
            Song song = Content.Load<Song>("Admin Battle");
            MediaPlayer.Play(song);

            // Causes the background music to loop
            MediaPlayer.IsRepeating = true;

            // Draws in the spritefont that will bw used to display scores
            Display = Content.Load<SpriteFont>("Display");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            // When 5 seconds have elapsed after the lives = 0 ends the game
            if (GameEnding)
            {
                if ((gameTime.TotalGameTime.TotalMilliseconds - TimeGameEnded) > CloseGameTime)
                {
                    Exit();
                }
                return;
            }

            // Making the ball move when the game starts
            ballposition = ballposition + ballspeed;

            // Sets paddle position
            Rectangle Paddle1 = new Rectangle((int)paddleposition.X, (int)paddleposition.Y, 150, 40);

            // Sets Ball Position
            Rectangle Ball1 = new Rectangle((int)ballposition.X, (int)ballposition.Y, 50, 50);

            // Causes the paddle to stop when it hits the edge of the screen
            if (paddleposition.X < 0)
                paddleposition.X = 0;

            // Causes the paddle to stop when it hits the edge of the screen
            if (paddleposition.X > 650)
                paddleposition.X = 650;

            // Causes the ball to bounce when it hits the edge of the screen
            if (ballposition.X < 0 || ballposition.X > 780)
                ballspeed.X = -ballspeed.X;

            // Causes the ball to bounce when hitting the paddle
            if (Paddle1.Intersects(Ball1) && ballspeed.Y > 0)
                ballspeed.Y = -ballspeed.Y;
                
            // Causes the ball to bounce when hitting the roof
            if (ballposition.Y < 0)
                ballspeed.Y = -ballspeed.Y;

            // Causes the ball to destroy a block and bounce when it hits a block
            for (int i = blocks.Count - 1; i >= 0; i-- )
            {
                Block block = blocks[i];
                if (Ball1.Intersects(block.CollisionRectangle))
                {
                    // Causes an explosion sound to play when the ball hits a block
                    Explosion1.Play();

                    //Destroys the block
                    blocks.Remove(block);

                    // Adds 20 to the score
                    Score = Score + 20;

                    //Causes the ball to bounce
                    ballspeed.Y = -ballspeed.Y;
                    break;

                }
            }

            // Causes the player to lose a life and the ball to respawn when the ball hits the ground
            if (ballposition.Y > 600)
            // Respawn Ball
            {
                Lives = Lives - 1;
                ballposition = new Vector2(400.0f, 200.0f);
                //Reset Speed
                ballspeed = new Vector2(01.0f, 5.0f);

            }
            // Level 2-3 Steps
            // When no more blocks exist
            if (blocks.Count == 0)
            {
            // Add 1 to the lives count, add 100 to the score count
            Lives = Lives + 1;
            Score = Score + 100;
            Level = Level + 1;

            // Reset the ball and paddle positions
            ballposition = new Vector2(400.0f, 300.0f);
            paddleposition = new Vector2(300.0f, 545.0f);

            // Clear the current list of blocks 
            blocks.Clear();
            if (Level == 1)
            {

                // Draw a new batch of blocks for level 2
                // Batch 1
                blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 200, 200));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 200));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 200));
                blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 320, 200));
                blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 360, 200));
                blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 400, 200));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 440, 200));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 480, 200));

                // Batch 2
                blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 200, 220));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 220));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 220));
                blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 320, 220));
                blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 360, 220));
                blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 400, 220));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 440, 220));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 480, 220));

                // Batch 3
                blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 200, 240));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 240));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 240));
                blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 320, 240));
                blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 360, 240));
                blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 400, 240));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 440, 240));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 480, 240));

                // Batch 4
                blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 200, 260));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 260));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 260));
                blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 320, 260));
                blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 360, 260));
                blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 400, 260));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 440, 260));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 480, 260));

                // Batch 5
                blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 200, 280));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 280));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 280));
                blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 320, 280));
                blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 360, 280));
                blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 400, 280));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 440, 280));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 480, 280));

                // Batch 6
                blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 200, 300));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 300));
                blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 300));
                blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 320, 300));
                blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 360, 300));
                blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 400, 300));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 440, 300));
                blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 480, 300));
            }
            if (Level == 2) {
               // Draw a new batch of blocks for level 3
               // Batch 1
               blocks.Add(new Block(Content.Load<Texture2D>("Block2"), 200, 200));
               blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 240, 200));
               blocks.Add(new Block(Content.Load<Texture2D>("Block1"), 280, 200));
               blocks.Add(new Block(Content.Load<Texture2D>("Block3"), 320, 200));
               blocks.Add(new Block(Content.Load<Texture2D>("Block4"), 360, 200));
               blocks.Add(new Block(Content.Load<Texture2D>("Block5"), 400, 200));
               blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 440, 200));
               blocks.Add(new Block(Content.Load<Texture2D>("Block6"), 480, 200));
            }
            

            
            }
            // Causes the ball to spin
            Spin = Spin + 00.5f;
            // Makes sure the ball's spin doesn't go above 360
            if (Spin > 360) Spin = 0;

                base.Update(gameTime);
            
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            if (GameEnding)
            {


                return;
            }
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            // Begin Spritebatch
            spriteBatch.Begin();

            spriteBatch.Draw(Background, Backgroundposition);

            // The extra code here is to make the ball spin without phasing through blocks
            spriteBatch.Draw(Ball, ballposition + new Vector2(Ball.Width / 2, Ball.Height / 2), null, Color.White, MathHelper.ToRadians(Spin), new Vector2(Ball.Width / 2, Ball.Height / 2), 1f, SpriteEffects.None, 1f);

            spriteBatch.Draw(Paddle, paddleposition);

            spriteBatch.DrawString(Display, "Lives:" + Lives, new Vector2(50, 50), Color.Red);

            spriteBatch.DrawString(Display, "Score:" + Score, new Vector2(700, 50), Color.Red);

            // Draws all the blocks in the list
            foreach (var block in blocks)
            {
                block.Draw(spriteBatch);
            }

            // For playing the sound effects
            Explosion1 = Content.Load<SoundEffect>("Explosion1");

            base.Update(gameTime);

            // Says game over and ends the game when the player's lives reach 0
            if (Lives == 0 && !GameEnding)
            {
                spriteBatch.DrawString(Display, "Game Over! Your Score Was: " + Score, new Vector2(300, 320), Color.Red);
                GameEnding = true;
                TimeGameEnded = gameTime.TotalGameTime.TotalMilliseconds;
            }

          

            spriteBatch.End();

            // Causes the paddle to move right when the right arrow is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                paddleposition = paddleposition + paddlespeed;

            // Causes the paddle to move left when the left arrow is pressed
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                paddleposition = paddleposition - paddlespeed;

            base.Draw(gameTime);
           
        }
       
    }
}
