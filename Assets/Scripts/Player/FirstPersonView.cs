using UnityEngine;

namespace Player
{
    public class FirstPersonView : MonoBehaviour
    {
        [SerializeField] private float sensitivityX = 8f;
        [SerializeField] private float sensitivityY = 0.5f;
        [SerializeField] private Transform playerCamera;
        [SerializeField] private float xClamp = 85f;

        private Vector2 mouse;
        private float xRotation;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            transform.Rotate(Vector3.up, mouse.x * Time.deltaTime);
            xRotation -= mouse.y;
            xRotation = Mathf.Clamp(xRotation, -xClamp, xClamp);
            var targetRotation = transform.eulerAngles;
            targetRotation.x = xRotation;
            playerCamera.eulerAngles = targetRotation;
        }

        public void ReceiveInput(Vector2 mouseInput)
        {
            mouse.x = mouseInput.x * sensitivityX;
            mouse.y = mouseInput.y * sensitivityY;
        }
    }
}