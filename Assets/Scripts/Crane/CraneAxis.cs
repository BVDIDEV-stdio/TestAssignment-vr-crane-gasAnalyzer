using UnityEngine;

/// <summary>
/// Single degree of freedom movement
/// </summary>
public class CraneAxis : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.forward;
    [SerializeField] private float speed = 3f;
    public float Speed
    {
        get => speed;
        set => speed = value;
    }
    [SerializeField] private float minLimit = -10f;
    [SerializeField] private float maxLimit = 10f;
    
    private int currentInput = 0;
    private float startProjection; 

    void Start()
    {
        startProjection = Vector3.Dot(transform.position, moveDirection.normalized);
    }

    private void FixedUpdate()
    {
        
        Vector3 movement = moveDirection.normalized * speed * currentInput * Time.deltaTime;
        Vector3 targetPos = transform.position + movement;

        float axis = Vector3.Dot(targetPos, moveDirection.normalized);

        float min = startProjection + minLimit;
        float max = startProjection + maxLimit;
        float clamped = Mathf.Clamp(axis, min, max);

        Vector3 delta = moveDirection.normalized * (clamped - Vector3.Dot(transform.position, moveDirection.normalized));
        transform.position += delta;
    }

    public void Move(int input)
    {
        currentInput = Mathf.Clamp(input, -1, 1);
    }

    public void Stop()
    {
        currentInput = 0;
    }

    /// <summary>
    /// Render axis and boundaries
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Vector3 dir = moveDirection.normalized;
        Vector3 center = Application.isPlaying ? transform.position : transform.position;

        float start = Application.isPlaying ? startProjection + minLimit : minLimit;
        float end = Application.isPlaying ? startProjection + maxLimit : maxLimit;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(center + dir * (start - startProjection), center + dir * (end - startProjection));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(center + dir * (start - startProjection), 0.3f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(center + dir * (end - startProjection), 0.3f);
    }
}
