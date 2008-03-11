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
    class MainMenu : FadeablePage
    {
        Texture2D logo;
        Texture2D button;
        SpriteBatch spriteBatch;

        public MainMenu(Engine engine, GameLayer layer, GamePages page): base(engine, layer, page)
        {

        }

        public override void LoadContent()
        {
            button = engine.Content.Load<Texture2D>("mainmenu-button");
            logo = engine.Content.Load<Texture2D>("logo");
            spriteBatch = new SpriteBatch(engine.GraphicsDevice);
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
            Rectangle mouseRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1,1);

            // Allows the game to exit
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                engine.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                if (layer.CurrentPage == GamePages.MainMenu)
                    layer.gotoPage(GamePages.MainMenu2);
                else
                    layer.gotoPage(GamePages.MainMenu);
            }

            Rectangle exitRect = new Rectangle(0, 0, 10, 10);
            if (mouseRect.Intersects(exitRect))
                draw = false;
            else
                draw = true;

            base.Update(gameTime);
        }
        bool draw = true;
        public override void Draw(GameTime gameTime)
        {
                // Draw the background image.
                spriteBatch.Begin(SpriteBlendMode.AlphaBlend);

                if (draw)
                {
                    spriteBatch.Draw(logo, new Rectangle(230, 20, 340, 160), new Color(255, 255, 255, Alpha));
                    spriteBatch.Draw(button, new Rectangle(30, 200, 400, 100), new Color(255, 255, 255, Alpha));
                    spriteBatch.Draw(button, new Rectangle(200, 325, 400, 100), new Color(255, 255, 255, Alpha));
                    spriteBatch.Draw(button, new Rectangle(370, 450, 400, 100), new Color(255, 255, 255, Alpha));
                }
                
                spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
