using UnityEngine;

[DefaultExecutionOrder(0)]
public class RelativelyFollowTransform : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset;
    private readonly float speed = 0.125f;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        var position = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, position, speed);
    }
}