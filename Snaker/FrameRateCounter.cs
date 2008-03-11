using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class FrameRateCounter : DrawableGameComponent
{
    ContentManager content;
    SpriteBatch spriteBatch;
    SpriteFont spriteFont;
    Vector2 position = new Vector2(10, 10);

    int frameRate = 0;
    int frameCounter = 0;
    TimeSpan elapsedTime = TimeSpan.Zero;

    public Vector2 Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    public FrameRateCounter(Microsoft.Xna.Framework.Game game)
        : base(game)
    {
        //use own content manager
        content = new ContentManager(game.Services);
        content.RootDirectory = "Content\\FrameRateCounter";
    }


    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        spriteFont = content.Load<SpriteFont>("Font");
    }


    protected override void UnloadContent()
    {
        
    }


    public override void Update(GameTime gameTime)
    {
        elapsedTime += gameTime.ElapsedGameTime;

        if (elapsedTime > TimeSpan.FromSeconds(1))
        {
            elapsedTime -= TimeSpan.FromSeconds(1);
            frameRate = frameCounter;
            frameCounter = 0;
        }
    }


    public override void Draw(GameTime gameTime)
    {
        frameCounter++;

        string fps = string.Format("FPS: {0}", frameRate);

        spriteBatch.Begin();

        spriteBatch.DrawString(spriteFont, fps, position+new Vector2(1,1), Color.Black);
        spriteBatch.DrawString(spriteFont, fps, position, Color.White);

        spriteBatch.End();
    }
}