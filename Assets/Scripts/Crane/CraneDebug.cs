using UnityEngine;

public class CraneDebug : MonoBehaviour
{
    [SerializeField] private CraneSystem crane;

    private void Update()
    {
        // Girder (W/S)
        if (Input.GetKey(KeyCode.W))
            crane.MoveForward();
        else if (Input.GetKey(KeyCode.S))
            crane.MoveBack();
        else
            crane.StopGirder();

        // Hoist (A/D)
        if (Input.GetKey(KeyCode.D))
            crane.MoveRight();
        else if (Input.GetKey(KeyCode.A))
            crane.MoveLeft();
        else
            crane.StopHoist();

        // Hook (Space/Ctrl)
        if (Input.GetKey(KeyCode.Space))
            crane.MoveUp();
        else if (Input.GetKey(KeyCode.LeftControl))
            crane.MoveDown();
        else
            crane.StopHook();
    }
}