using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.Content;

namespace Snaker
{
    class OptionsMenu : FadeablePage
    {
        Texture2D logo;
        Texture2D button;
        Texture2D exit;
        SpriteBatch spriteBatch;
        HoverButton exitButton;

        public OptionsMenu(Engine engine, GameLayer layer, GamePages page): base(engine, layer, page)
        {
            exitButton = new HoverButton(this, "exit", new Point(20, 450));
            exitButton.OnClick += onExitClick;
        }

        public override void LoadContent()
        {
            button = engine.Content.Load<Texture2D>("mainmenu-button");
            logo = engine.Content.Load<Texture2D>("logo");
            spriteBatch = new SpriteBatch(engine.GraphicsDevice);

            exitButton.LoadContent();

            base.LoadContent();
        }

        public override void Goto()
        {

        }
        public override void Leave()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (FadeState == FadeStates.Visible)
            {
                Rectangle mouseRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);

                // Allows the game to exit
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    engine.Exit();
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                     layer.gotoPage(GamePages.MainMenu);
                }

                exitButton.Update();
            }
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            Color alphaColor = new Color(255, 255, 255, Alpha);
            // Draw the background image.
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

            spriteBatch.Draw(logo, new Rectangle(230, 20, 340, 160), alphaColor);
            spriteBatch.Draw(button, new Rectangle(30, 200, 400, 100), alphaColor);
            spriteBatch.Draw(button, new Rectangle(200, 325, 400, 100), alphaColor);
            spriteBatch.Draw(button, new Rectangle(370, 450, 400, 100), alphaColor);

            spriteBatch.End();

            exitButton.Draw();
            base.Draw(gameTime);
        }

        protected void onExitClick(object sender, EventArgs eventArgs)
        {
            layer.gotoPage(GamePages.MainMenu);
        }
    }
}
