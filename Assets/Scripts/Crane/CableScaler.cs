using UnityEngine;

public class CableScaler : MonoBehaviour
{
    [Header("Connection Points")]
    [SerializeField] private Transform origin;  // for hoist
    [SerializeField] private Transform movingPart;    // for hook
    
    [Header("Cable Settings")]
    [SerializeField] private Vector3 scaleAxis = Vector3.up;

    private float initialDistance;

    void Start()
    {
        if (origin == null || movingPart == null)
        {
            Debug.LogWarning("Origin and MovingPart transforms must be assigned.");
            enabled = false;
            return;
        }
        initialDistance = Vector3.Distance(origin.position, movingPart.position);
    }

    void LateUpdate()
    {
        if (initialDistance <= 0) return;

        float currentDistance = Vector3.Distance(origin.position, movingPart.position);
        float scaleFactor = currentDistance / initialDistance;

        Vector3 scale = transform.localScale;

        if (scaleAxis.x != 0)
            scale.x = Mathf.Abs(scale.x) * scaleFactor * Mathf.Sign(scaleAxis.x);
        if (scaleAxis.y != 0)
            scale.y = Mathf.Abs(scale.y) * scaleFactor * Mathf.Sign(scaleAxis.y);
        if (scaleAxis.z != 0)
            scale.z = Mathf.Abs(scale.z) * scaleFactor * Mathf.Sign(scaleAxis.z);

        transform.localScale = scale;
        initialDistance = currentDistance;
}

}