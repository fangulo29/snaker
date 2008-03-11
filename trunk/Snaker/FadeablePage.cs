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
    public enum FadeStates
    { 
        None,
        Wait,
        FadeIn,
        Visible,
        FadeOut
    }

    /// <summary>
    /// This is a Page, which can be faded in and out
    /// by using the FadeState field.
    /// </summary>
    public class FadeablePage
    {
        
        public Engine engine;
        protected GameLayer layer;
        const int fadeLength = 60;
        int fadeStep = 0;
        public FadeStates FadeState = FadeStates.None;
        GamePages page;

        public byte Alpha
        {
            get
            {
                switch (FadeState)
                { 
                    case FadeStates.FadeIn:
                        return (byte)(255 * fadeStep / fadeLength);
                    case FadeStates.FadeOut:
                        return (byte)(255 * (fadeLength-fadeStep) / fadeLength);
                    case FadeStates.Visible:
                        return 255;
                    default:
                        return 0;
                }
            }
        }

        public Color AlphaColor
        {
            get {
                return new Color(255, 255, 255, Alpha);
            }
        }


        public FadeablePage(Engine engine, GameLayer layer,GamePages page)
        {
            this.engine = engine;
            this.layer = layer;
            this.page = page;
            layer.Pages[page] = this;
        }

        public virtual void LoadContent()
        {
        }

        public virtual void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public virtual void Initialize()
        {
            // TODO: Add your initialization code here
        }

        /// <summary>
        /// This is called when the Page is joined.
        /// </summary>
        public virtual void Goto()
        {
        
        }

        /// <summary>
        /// This is called when the Page is left.
        /// </summary>
        public virtual void Leave()
        {

        }

        /// <summary>
        /// This is called when the page should be updated.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public virtual void Update(GameTime gameTime)
        {
            if (FadeState == FadeStates.Wait)
            {
                fadeStep++;
                if (fadeStep > fadeLength)
                {
                    layer.CurrentPage = page;
                    Goto();
                    fadeStep = 0;
                    FadeState = FadeStates.FadeIn;
                }
            }
            else if (FadeState == FadeStates.FadeIn)
            {
                fadeStep++;
                if (fadeStep > fadeLength)
                {
                    fadeStep = 0;
                    FadeState = FadeStates.Visible;
                }
            }
            else if (FadeState == FadeStates.FadeOut)
            {
                fadeStep++;
                if (fadeStep > fadeLength)
                {
                    fadeStep = 0;
                    Leave();
                    FadeState = FadeStates.None;
                }
            }
        }

        /// <summary>
        /// This is called when the Page should be drawn.
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Draw(GameTime gameTime)
        {
            
        }
    }
}