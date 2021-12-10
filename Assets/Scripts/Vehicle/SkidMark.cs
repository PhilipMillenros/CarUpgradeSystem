using UnityEngine;

namespace Vehicle
{
    public class SkidMark : MonoBehaviour
    {
        [SerializeField] private TrailRenderer[] skidMarkTrails;

        public void SetSkidEmitter(bool isEmitting)
        {
            for (var i = 0; i < skidMarkTrails.Length; i++) skidMarkTrails[i].emitting = isEmitting;
        }
    }
}