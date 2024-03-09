using UnityEngine;


namespace JALJ.EmotionalTissue
{
    public class ClothController : MonoBehaviour
    {
        public static ClothController Instance { get; private set; }
        public Cloth ClothInstance { get; private set; }

        Mesh _mesh;
        int _minIdx;

        public float MinY { get; private set; }
        public Vector3 MinVertice => ClothInstance.vertices[_minIdx];
        public Vector3 MinNormal => ClothInstance.normals[_minIdx];
        public Vector3 MinMeshVertice => _mesh.vertices[_minIdx];

        private void Awake()
        {
            // Singleton.
            if (Instance == null)
                Instance = this;
            else
                Destroy(this);

            ClothInstance = GetComponent<Cloth>();
            _mesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
        }

        private void Update()
        {
            for (int i = 0; i < ClothInstance.vertices.Length; i++)
                if (ClothInstance.vertices[i].y < MinY)
                {
                    _minIdx = i;
                    MinY = MinVertice.y;
                }
        }
    }
}