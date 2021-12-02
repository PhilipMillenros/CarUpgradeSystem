using UnityEngine;

namespace Player
{
    public class ThirdPersonCamera : MonoBehaviour
    {
        [SerializeField] private Transform lookAt;
        public Camera cam;
        public float distance = 10.0f;
        public float sensitivity = 30.0f;
        
        private float mouseX;
        private float mouseY;
        private float yMin = -50.0f;
        private float yMax = 50.0f;

        public void SetInput(Vector2 input)
        {
            mouseX += input.x * Time.deltaTime * sensitivity;
            mouseY += -input.y * Time.deltaTime * sensitivity;
        
            mouseY = Mathf.Clamp(mouseY, yMin, yMax);

            Vector3 Direction = new Vector3(0, 0, -distance) + transform.forward;
            Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);
            cam.transform.position = lookAt.position + rotation * Direction;
        
            cam.transform.LookAt(lookAt.position);
        }
    }
}
