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
    public delegate void OnClickDelegate(object sender, EventArgs eventArgs);

    class HoverButton
    {
        SpriteBatch spriteBatch;
        string spriteName;
        Texture2D sprite;
        int width;
        int height;
        Rectangle intersectRect;
        FadeablePage page;
        Point position;
        bool hover = false;

        public bool IsHover
        {
            get
            {
                return hover;
            }
        }

        public event OnClickDelegate OnClick;

        public HoverButton(FadeablePage page, string spriteName, Point position)
        {
            spriteBatch = new SpriteBatch(page.engine.GraphicsDevice);
            this.spriteName = spriteName;
            this.page = page;
            this.position = position;
        }

        public void LoadContent()
        {
            spriteBatch = new SpriteBatch(page.engine.GraphicsDevice);
            sprite = page.engine.Content.Load<Texture2D>(spriteName);
            width = sprite.Width / 2;
            height = sprite.Height;
            intersectRect = new Rectangle(position.X, position.Y, width, height);
        }

        public void Update()
        {
            Rectangle mouseRect = new Rectangle(Mouse.GetState().X, Mouse.GetState().Y, 1, 1);
            hover = intersectRect.Intersects(mouseRect);
            if (hover && Mouse.GetState().LeftButton == ButtonState.Pressed)
                OnClickEvent();

        }

        public void Draw()
        { 
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            if(hover)
                spriteBatch.Draw(sprite, intersectRect, new Rectangle(width,0, width,height), page.AlphaColor);
            else
                spriteBatch.Draw(sprite, intersectRect, new Rectangle(0, 0, width, height), page.AlphaColor);

            spriteBatch.End();
        }

        protected void OnClickEvent()
        {
            // If there are any event handlers attached,
            // raise the event.
            hover = false;
            if (OnClick != null)
            {
                OnClick(this, new EventArgs());
            }
        }
    }
}
