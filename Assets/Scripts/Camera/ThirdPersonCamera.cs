using UnityEngine;

namespace Player
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] private Transform lookAt;
        public Camera cam;
        public float distance = 10.0f;
        public float sensitivity = 30.0f;
        [SerializeField] private float yMin = -50.0f;
        [SerializeField] private float yMax = 50.0f;

        private float mouseX;
        private float mouseY;

        public void SetInput(Vector2 input)
        {
            mouseX += input.x * Time.deltaTime * sensitivity;
            mouseY += input.y * Time.deltaTime * sensitivity;

            mouseY = Mathf.Clamp(mouseY, yMin, yMax);

            var direction = new Vector3(0, 0, -distance) + cam.transform.forward;
            var rotation = Quaternion.Euler(mouseY, mouseX, 0);
            cam.transform.position = lookAt.position + rotation * direction;

            cam.transform.LookAt(lookAt.position);
        }
    }
}