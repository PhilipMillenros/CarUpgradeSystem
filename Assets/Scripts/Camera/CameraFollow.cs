using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform target;
    [SerializeField] private float damping = 1;

    private void Awake()
    {
        offset = target.position - transform.position;
    }

    private void Update()
    {
        var currentAngle = transform.eulerAngles.y;
        var desiredAngle = target.transform.eulerAngles.y;
        var angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

        var rotation = Quaternion.Euler(0, angle, 0);
        transform.position = target.transform.position - rotation * offset;

        transform.LookAt(target.transform);
    }
}