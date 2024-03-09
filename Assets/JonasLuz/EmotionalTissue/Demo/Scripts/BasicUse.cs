using UnityEngine;
using JALJ.EmotionalTissue.Widget;

namespace JALJ.EmotionalTissue.Unity.Examples
{
    public class BasicUse : MonoBehaviour
    {
        public EmotionalTissueControl etRef;
        public NumberOfColors numberOfColors;
        public bool testReset = true;

        private void Start()
        {
            // Adding six emotions and colors.
            etRef.InitColors(numberOfColors);
            etRef.Add("Trust", Color.blue);
            etRef.Add("Fear", Color.yellow);
            etRef.Add("Surprise", Color.red);
            etRef.Add("Anticipation", Color.green);
            etRef.Add("Anger", Color.cyan);
            etRef.Add("Joy", Color.magenta);
            etRef.Add("Sadness", Color.gray);

            // Setting up the EmotionalTissue.
            etRef.SetValue("Trust", 1f);
            etRef.SetValue("Fear", .5f);
            etRef.SetValue("Surprise", .75f);
            etRef.SetValue("Anticipation", .25f);
            if (testReset) 
                etRef.ResetValue("Surprise");
        }
    }
}