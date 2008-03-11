#region File Description
//-----------------------------------------------------------------------------
// BloomSettings.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

namespace Snaker
{
    /// <summary>
    /// Class holds all the settings used to tweak the bloom effect.
    /// </summary>
    public class BloomSettings
    {
        #region Fields


        // Name of a preset bloom setting, for display to the user.
        public string Name
        {
            get
            {
                return name+" "+mixValue*100+"%";
            }
        }
        string name;

        //Value from 0 to 1
        //Zero means no effect, 1 means full effect 
        public float MixValue
        {
            get
            {
                return mixValue;
            }
            set
            {
                mixValue = System.Math.Max(0,System.Math.Min(1,value));
                bloomThreshold = standardBloomThreshold + (targetBloomThreshold - standardBloomThreshold) * mixValue;
                blurAmount = standardBlurAmount + (targetBlurAmount - standardBlurAmount) * mixValue;
                bloomIntensity = standardBloomIntensity + (targetBloomIntensity - standardBloomIntensity) * mixValue;
                baseIntensity = standardBaseIntensity + (targetBaseIntensity - standardBaseIntensity) * mixValue;
                bloomSaturation = standardBloomSaturation + (targetBloomSaturation - standardBloomSaturation) * mixValue;
                baseSaturation = standardBaseSaturation + (targetBaseSaturation - standardBaseSaturation) * mixValue;
            }
        }
        float mixValue;



        // Controls how bright a pixel needs to be before it will bloom.
        // Zero makes everything bloom equally, while higher values select
        // only brighter colors. Somewhere between 0.25 and 0.5 is good.
        public float BloomThreshold
        {
            get
            {
                return bloomThreshold;
            }
        }
        float bloomThreshold;
        readonly float targetBloomThreshold;
        const float standardBloomThreshold = 0;


        // Controls how much blurring is applied to the bloom image.
        // The typical range is from 1 up to 10 or so.
        public float BlurAmount
        {
            get
            {
                return blurAmount;
            }
        }
        float blurAmount;
        readonly float targetBlurAmount;
        const float standardBlurAmount = 8;


        // Controls the amount of the bloom and base images that
        // will be mixed into the final scene. Range 0 to 1.
        public float BloomIntensity
        {
            get
            {
                return bloomIntensity;
            }
        }
        float bloomIntensity;
        readonly float targetBloomIntensity;
        const float standardBloomIntensity = 0;

        public float BaseIntensity
        {
            get
            {
                return baseIntensity;
            }
        }
        float baseIntensity;
        readonly float targetBaseIntensity;
        const float standardBaseIntensity = 1;


        // Independently control the color saturation of the bloom and
        // base images. Zero is totally desaturated, 1.0 leaves saturation
        // unchanged, while higher values increase the saturation level.
        public float BloomSaturation
        {
            get
            {
                return bloomSaturation;
            }
        }
        float bloomSaturation;
        readonly float targetBloomSaturation;
        const float standardBloomSaturation = 1;

        public float BaseSaturation
        {
            get
            {
                return baseSaturation;    
            }
        }
        float baseSaturation;
        readonly float targetBaseSaturation;
        const float standardBaseSaturation = 1;


        #endregion


        /// <summary>
        /// Constructs a new bloom settings descriptor.
        /// </summary>
        public BloomSettings(string name, float bloomThreshold, float blurAmount,
                             float bloomIntensity, float baseIntensity,
                             float bloomSaturation, float baseSaturation)
        {
            this.name = name;
            targetBloomThreshold = bloomThreshold;
            targetBlurAmount = blurAmount;
            targetBloomIntensity = bloomIntensity;
            targetBaseIntensity = baseIntensity;
            targetBloomSaturation = bloomSaturation;
            targetBaseSaturation = baseSaturation;
            MixValue = 0;
        }
        

        /// <summary>
        /// Table of preset bloom settings, used by the sample program.
        /// </summary>
        public static BloomSettings[] PresetSettings =
        {
            //                Name           Thresh  Blur Bloom  Base  BloomSat BaseSat
            new BloomSettings("Blur",          0,      2,   1,     0.1f, 0,       1),
        };
    }
}
