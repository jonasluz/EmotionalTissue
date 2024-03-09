using UnityEngine;


namespace JALJ.EmotionalTissue
{
    public class Hammer : MonoBehaviour
    {
        public HammersManager Manager { get; set; }

        public float frequency;
        public float Speed => Manager.Amplitude * frequency;

        int _direction = 1;

        private void FixedUpdate()
        {
            var p = transform.position;
            var y = p.y;
            if (y < Manager.bottomYPosition) _direction = 1;
            else if (y > Manager.topYPosition) _direction = -1;

            var diff = Speed * _direction * Time.fixedDeltaTime;
            transform.position = new Vector3(p.x, y + diff, p.z);
        }
    }
}