using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// So... since no max distance requirements are stated
/// I use Find with tag method, which might be unoptimized
/// </summary>

// P. S.   if I'll have time for this I'll make a trigger sphere based dangerObj search,
// which looks more resource friendly

//TODO consider the thing above
public class DangerFinder : MonoBehaviour
{
    float distance;
    public float Distance => distance;
    public string DistanceToStr
    {
        get
        {
            return distance switch
            {
                < 0 => "what",
                < 0.3f => "RUN",
                > 999 => "999",
                _ => $"{Mathf.Round(distance * 10f) / 10f:F1}m"
            };
        }
    }
    private Transform nearestDanger;
    private float nearestDistance = Mathf.Infinity;

    void Update()
    {
        FindNearestDanger();
        if (nearestDanger != null)
        {
            distance = Vector3.Distance(transform.position, nearestDanger.position);
            Debug.Log($"[{name}] Distance: {distance}");
        }
        else
        {
            distance = -1;
        }
    }

    void FindNearestDanger()
    {
        GameObject[] dangers = GameObject.FindGameObjectsWithTag("Danger");
        nearestDistance = Mathf.Infinity;
        nearestDanger = null;

        foreach (GameObject danger in dangers)
        {
            float dist = Vector3.SqrMagnitude(danger.transform.position - transform.position);
            if (dist < nearestDistance)
            {
                nearestDistance = dist;
                nearestDanger = danger.transform;
            }
        }
    }
}
