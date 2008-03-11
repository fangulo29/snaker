using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace Snaker
{
    public enum GamePages
    {
        MainMenu = 0,
        MainMenu2 = 1
    }
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class GameLayer : Microsoft.Xna.Framework.DrawableGameComponent
    {
        Engine engine;
        Texture2D background;
        SpriteBatch spriteBatch;

        public GamePages CurrentPage;
        public Dictionary<GamePages,FadeablePage> Pages = new Dictionary<GamePages,FadeablePage>();

        public GameLayer(Game game) : base(game)
        {
            engine = game as Engine;
            new MainMenu(engine, this, GamePages.MainMenu);
            new MainMenu(engine, this, GamePages.MainMenu2);
            // TODO: Construct any child components here
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here
            foreach(FadeablePage page in Pages.Values)
                page.Initialize();
            base.Initialize();

            CurrentPage = GamePages.MainMenu;
            Pages[CurrentPage].FadeState = FadeStates.FadeIn;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(engine.GraphicsDevice);
            background = engine.Content.Load<Texture2D>("background");
            foreach (FadeablePage page in Pages.Values)
                page.LoadContent();

            base.LoadContent();
        }

        protected override void UnloadContent()
        {
            foreach (FadeablePage page in Pages.Values)
                page.UnloadContent();

            base.UnloadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            // Draw the background image.
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 600), Color.White);
            spriteBatch.End();

            foreach (FadeablePage page in Pages.Values)
            {
                if (page.FadeState != FadeStates.None && page.FadeState != FadeStates.Wait)
                    page.Draw(gameTime);
            }

            base.Draw(gameTime);
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            // TODO: Add your update code here
            foreach (FadeablePage page in Pages.Values)
            {
                if (page.FadeState != FadeStates.None)
                    page.Update(gameTime);
            }

            base.Update(gameTime);
        }

        public void gotoPage(GamePages page)
        {
            Pages[CurrentPage].FadeState = FadeStates.FadeOut;
            Pages[page].FadeState = FadeStates.Wait;
        }
    }
}