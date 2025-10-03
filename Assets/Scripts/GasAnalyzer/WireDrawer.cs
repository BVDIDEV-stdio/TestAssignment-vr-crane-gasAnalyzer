using System.Linq.Expressions;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class WireDrawer : MonoBehaviour
{
    [SerializeField]
    private Transform source;
    [SerializeField]
    private Transform destination;

    [SerializeField]
    private LineRenderer line;

    void Awake()
    {
        if (line == null)
            line = GetComponent<LineRenderer>();


        if (line == null)
            Debug.Log("No lineRenderer found");
        else
            line.positionCount = 2;

    }

    void Update()
    {
        if (source == null || destination == null) return;

        line.SetPosition(0, source.position);
        line.SetPosition(1, destination.position);
    }
}
