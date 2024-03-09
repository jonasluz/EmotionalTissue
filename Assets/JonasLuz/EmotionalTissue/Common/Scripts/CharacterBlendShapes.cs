using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;


namespace JALJ.Common
{
    [ExecuteAlways]
    public class CharacterBlendShapes : MonoBehaviour
    {
        public string[] blendShapesNames;

        SkinnedMeshRenderer _charMeshRenderer;

        public void RetrieveBlendshapes()
        {
            // Retrive the first mesh renderer from the children.
            _charMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

            // Retrieve the blendshapes' indexes.
            var mesh = _charMeshRenderer.sharedMesh;
            blendShapesNames = new string[mesh.blendShapeCount];
            for (int i = 0; i < mesh.blendShapeCount; i++)
                blendShapesNames[i] = mesh.GetBlendShapeName(i);
        }

        #region MonoBehaviour impl.
        private void Awake()
        {
            RetrieveBlendshapes();
        }
        #endregion Monobehaviour impl.

        #region Indexed access
        int IndexOf(string key) => Array.IndexOf<string>(blendShapesNames, key);

        public float this[string key]
        {
            get => _charMeshRenderer.GetBlendShapeWeight(IndexOf(key));
            set => _charMeshRenderer.SetBlendShapeWeight(IndexOf(key), value);
        }
        
        public ICollection<string> Keys => blendShapesNames;
        
        public ICollection<float> Values 
            => blendShapesNames.Select(bs => this[bs]).ToArray();

        public int Count => blendShapesNames.Length;

        public bool Contains(KeyValuePair<string, float> item)
            => blendShapesNames.Contains(item.Key) && this[item.Key] == item.Value;

        public bool ContainsKey(string key) => blendShapesNames.Contains(key);

        public bool TryGetValue(string key, out float value)
        {
            if (blendShapesNames.Contains(key))
            {
                value = this[key];
                return true;
            }
            else
            {
                value = default(float);
                return false;
            }
        }
        #endregion Indexed access
    }
}