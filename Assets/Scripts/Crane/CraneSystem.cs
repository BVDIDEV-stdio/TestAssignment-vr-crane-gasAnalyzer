using UnityEngine;

public class CraneSystem : MonoBehaviour
{
    [Header("Crane Components")]
    [SerializeField]
    private CraneAxis girderMover;
    [SerializeField]
    private CraneAxis hoistMover;
    [SerializeField]
    private CraneAxis hookMover;


    [Header("Movement Inversion setup")]
    [SerializeField]
    private bool invertForwardBack;
    [SerializeField]
    private bool invertRightLeft;
    [SerializeField]
    private bool invertUpDown; // ofc you most probably won't need this one but still


    [Header("Movement Speed Setup")]
    [SerializeField]
    private float forwardSpeed = 3;
    [SerializeField]
    private float backSpeed = 3;

    [SerializeField]
    private float rightSpeed = 3;
    [SerializeField]
    private float leftSpeed = 3;

    [SerializeField]
    private float upSpeed = 3;
    [SerializeField]
    private float downSpeed = 3;
    

    // API to control 
    public void MoveForward()
    {
        girderMover.Speed = forwardSpeed;
        girderMover.Move(1 * (invertForwardBack ? -1 : 1));
    }
    public void MoveBack() 
    {
        girderMover.Speed = backSpeed;
        girderMover.Move(-1 * (invertForwardBack ? -1 : 1));
    } 
    public void StopGirder() 
    {
        girderMover.Stop();
    } 

    public void MoveRight() 
    {
        hoistMover.Speed = rightSpeed;
        hoistMover.Move(1 * (invertRightLeft ? -1 : 1));
    } 
    public void MoveLeft() 
    {
        hoistMover.Speed = leftSpeed;
        hoistMover.Move(-1 * (invertRightLeft ? -1 : 1));
    } 
    public void StopHoist() 
    {
        hoistMover.Stop();
    } 

    public void MoveUp() 
    {
        hookMover.Speed = upSpeed;
        hookMover.Move(1 * (invertUpDown ? -1 : 1));
    } 
    public void MoveDown() 
    {
        hookMover.Speed = downSpeed;
        hookMover.Move(-1 * (invertUpDown ? -1 : 1));
    } 
    public void StopHook() 
    {
        hookMover.Stop();
    } 
}