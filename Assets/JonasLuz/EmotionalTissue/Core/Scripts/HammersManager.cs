using UnityEngine;


namespace JALJ.EmotionalTissue
{
    public class HammersManager : MonoBehaviour
    {
        [Header("References")]
        public Hammer[] hammers;

        [Header("Setup")]
        [Range(0, 1)]
        public float timeScale = 1f;

        [Header("Hammers Config")]
        public float topYPosition = 2.5f;
        public float bottomYPosition = -.5f;
        public float defaultFrequency = 1f;
        public bool resetFrequencyOnRun = true;

        public float Amplitude => (topYPosition - bottomYPosition) * 2;

        private void Awake()
        {
            Time.timeScale = timeScale;

            hammers = GetComponentsInChildren<Hammer>();
        }

        private void Start()
        {
            var colliders = new ClothSphereColliderPair[hammers.Length];
            int idx = 0;

            foreach (var hammer in hammers)
            {
                hammer.Manager = this;
                if (resetFrequencyOnRun) hammer.frequency = defaultFrequency;
                colliders[idx++] =
                    new ClothSphereColliderPair(hammer.GetComponent<SphereCollider>());
            }

            var cloth = ClothController.Instance.GetComponent<Cloth>();
            cloth.sphereColliders = colliders;
        }

        public void SetFrequency(float frequency)
        {
            foreach (var hammer in hammers)
                hammer.frequency = frequency;
        }
    }
}