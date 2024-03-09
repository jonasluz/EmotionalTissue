using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace JALJ.EmotionalTissue.Widget
{
    public partial class EmotionalTissueControl : MonoBehaviour
    {
        [SerializeField]
        ClothController _controller;
        [SerializeField]
        HammersManager _hammersManager;

        Material _material;
        IList<string> _emotions = new List<string>(4);

        private void Awake()
        {
            _material = _controller.GetComponent<SkinnedMeshRenderer>().material;
        }

        float[] _intensities;
        public float[] Intensities { 
            get 
            { 
                if (_intensities == null)
                {
                    var intensities1to4 = _material.GetVector(SHADER_PROP_DICT["Intensities1to4"]);
                    var intensities5to8 = _material.GetVector(SHADER_PROP_DICT["Intensities5to8"]);
                    _intensities = new float[8]
                    {
                        intensities1to4.x, intensities1to4.y, intensities1to4.z, intensities1to4.w,
                        intensities5to8.x, intensities5to8.y, intensities5to8.z, intensities5to8.w
                    };
                }
                return _intensities; 
            } 
        }

        int IndexOf(string emotion) => _emotions.IndexOf(emotion);

        public void InitColors(NumberOfColors numberOfColors) => _material.SetFloat(SHADER_PROP_DICT["Sections"], (int)numberOfColors);

        public void Add(string emotion, Color color)
        {
            _emotions.Add(emotion);           
            SetColor(emotion, color);
            Debug.Log($"Added: {emotion} - {color}");
        }

        public Color GetColor(int index) => _material.GetColor(index);

        public Color GetColor(string emotion) => _material.GetColor(IndexOf(emotion));

        public void SetColor(int index, Color color)
        {
            try
            {
                _material.SetColor(SHADER_COLOR_PROP[index], color);
            } catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public void SetColor(string emotion, Color color) => SetColor(IndexOf(emotion), color);

        public float GetValue(int index) => Intensities[index];

        public float GetValue(string emotion) => GetValue(IndexOf(emotion));

        public void SetValue(int index, float value)
        {
            try
            {
                Vector4 intensities;
                string propName;
                if (index < 4)
                {
                    intensities = new Vector4(Intensities[0], Intensities[1], Intensities[2], Intensities[3]);
                    propName = SHADER_PROP_DICT["Intensities1to4"];
                }
                else
                {
                    intensities = new Vector4(Intensities[4], Intensities[5], Intensities[6], Intensities[7]);
                    propName = SHADER_PROP_DICT["Intensities5to8"];
                }

                // Beating/color intensities discrepance workaround.
                var factor = 5;
                var power = value * factor;
                switch (index % 4)
                {
                    case 0: intensities.x = power; break;
                    case 1: intensities.y = power; break;
                    case 2: intensities.z = power; break;
                    case 3: intensities.w = power; break;
                    default:
                        return;
                }
                _material.SetVector(propName, intensities);

                // Beating/color intensities discrepance workaround.
                var beatFrequency = Mathf.Max(intensities[0], intensities[1], intensities[2], intensities[3]) / factor;
                _hammersManager.SetFrequency(beatFrequency);
                Debug.Log(beatFrequency);
            }
            catch (IndexOutOfRangeException)
            {
                return;
            }
        }

        public void SetValue(string emotion, float value) => SetValue(IndexOf(emotion), value);

        public void ResetValue(int index) => SetValue(index, 0);

        public void ResetValue(string emotion) => SetValue(emotion, 0);

        public void ResetAll()
        {
            _material.SetVector(SHADER_PROP_DICT["Intensities1to4"], Vector4.zero);
            _material.SetVector(SHADER_PROP_DICT["Intensities5to8"], Vector4.zero);
        }
    }
}