using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEditor.SceneManagement;
using UnityEngine;

public class CarController : MonoBehaviour, IInputListener
{
    private Vector2Int input;
    [SerializeField] private ThirdPersonCamera thirdPersonCamera;
    [SerializeField] private CarMotor motor;
    [SerializeField] private Steering steering;
    private void Start()
    {
        InputManager.instance.SetInputListener(this);
    }

    public void Move(Vector2 input)
    {
        steering.SetSteering(input.x);
        motor.Thrust(input.y);
    }
    public void LookAround(Vector2 input)
    {
        thirdPersonCamera.SetInput(input);
    }
    public void JumpAction()
    {
        
    }
    public void PrimaryAction()
    {
        
    }

    public void SecondaryAction()
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
