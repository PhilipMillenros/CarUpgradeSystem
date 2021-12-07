using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour, IInputListener
{
    private Vector2Int input;
    [SerializeField] private CarMotor motor;
    [SerializeField] private Steering steering;
    public List<Gun> guns = new List<Gun>();
    private float primaryActionDelay = 1;
    private bool primaryActionHeld;
    private bool secondaryActionHeld;
    private void Start()
    {
        InputManager.instance.SetInputListener(this);
    }

    public void MoveAction(Vector2 input)
    {
        steering.SetSteering(input);
        motor.Thrust(input);
    }
    public void MouseAxis(Vector2 input)
    {
        //thirdPersonCamera.SetInput(input);
    }
    public void JumpAction()
    {
        
    }
    public void PrimaryAction(InputAction.CallbackContext ctx)
    {
        for (int i = 0; i < guns.Count; i++)
        {
            guns[i].IsShooting(ctx.control.IsPressed());
        }
    }

    public void SecondaryAction(InputAction.CallbackContext ctx)
    {
        
    }
    public void SwitchAction()
    {
        
    }
    public void SpecialAction()
    {
        
    }
    public void UseAction()
    {
        
    }
}
