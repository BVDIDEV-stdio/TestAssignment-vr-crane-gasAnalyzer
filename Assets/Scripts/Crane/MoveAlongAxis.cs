using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class MoveAlongAxis : MonoBehaviour
{
    public enum WorldAxis { X, Y, Z };

    [Header("Movement Settings")]
    public bool useLocalAxis = true;
    public float speed = 1f;
    public Axis MoveAxis;
    public Vector3 direction => MoveAxis switch
    {
        Axis.X => Vector3.right,
        Axis.Y => Vector3.up,
        Axis.Z => Vector3.forward,
        _ => Vector3.zero
    };

    [Header("Bounds (Transforms)")]
    public Transform minBoundTransform;
    public Transform maxBoundTransform;


    [Header("Runtime Input")]
    [Range(-1f, 1f)] // for now
    public float moveInput = 0f;

    public void SetMoveInput(float value)
    {
        moveInput = value;
    }

    void Update()
    {

    }
}
