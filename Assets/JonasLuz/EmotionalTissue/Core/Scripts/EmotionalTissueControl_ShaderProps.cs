using System;
using System.Collections.Generic;
using UnityEngine;

namespace JALJ.EmotionalTissue.Widget
{
    public enum NumberOfColors
    {
        Four = 4, 
        Six = 6, 
        Eight = 8
    }

    public partial class EmotionalTissueControl : MonoBehaviour
    {
        private readonly IDictionary<string, string> SHADER_PROP_DICT 
            = new Dictionary<string, string>()
        {
            { "Sections", "_Emotions" },
            { "Intensities1to4", "_Emotion_Intensities_1_to_4" },
            { "Intensities5to8", "_Emotion_Intensities_5_to_8" },
        };
        private readonly string[] SHADER_COLOR_PROP = new string[]
        {
            "_Emotion_1_Color", "_Emotion_2_Color", "_Emotion_3_Color", "_Emotion_4_Color",
            "_Emotion_5_Color", "_Emotion_6_Color", "_Emotion_7_Color", "_Emotion_8_Color",
        };
    }
}