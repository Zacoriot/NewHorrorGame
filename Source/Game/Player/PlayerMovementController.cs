using FlaxEngine;

namespace Game;

/// <summary>
/// PlayerMovementController Script.
/// </summary>
public class PlayerMovementController : Script
{
    CharacterController _CharacterController;

    [Header("==MOVEMENT==")]
    [ShowInEditor, Serialize] float _MinSpeed;
    [ShowInEditor, Serialize] float _MoveTransitionSpeed;
    [ShowInEditor, Serialize] float _MovementSpeed;
    [ShowInEditor, Serialize] float _SprintSpeed;
    float _CurrentSpeed; 
    float _DesiredSpeed; 
    Vector3 _FallingMovement;

    [Header("==JUMP==")]
    [ShowInEditor, Serialize] float _JumpHeight;

    [Header("==SPRINT==")]
    bool _IsSprinting;

    float _Gravity;

    public override void OnEnable()
    {
        InputManager.GetJump().Pressed += Jump;
        InputManager.GetSprint().Pressed += StartSprint;
        InputManager.GetSprint().Released += EndSprint;
    }

    public override void OnStart()
    {
        _CharacterController = (CharacterController)Actor;

        _Gravity = Physics.Gravity.Y;
    }

    public override void OnUpdate()
    {
        SwapSpeeds();

        if(InputManager.GetMovementAxis().Length > 0.1)
        {
            if(_CurrentSpeed < _MinSpeed)
            {
                _CurrentSpeed = _MinSpeed;
            }

            _CurrentSpeed = Mathf.Lerp(_CurrentSpeed,
                                _DesiredSpeed,
                                Time.DeltaTime * _MoveTransitionSpeed);
        }
        else
        {
            _CurrentSpeed = 0;
        }
        
        HandleMovement();
    }

    void HandleMovement()
    {
        if(!_CharacterController.IsGrounded)
        {
            _FallingMovement.Y += _Gravity * Time.DeltaTime;
        }

        Vector3 moveInput = Actor.Transform.Forward * InputManager.GetMovementAxis().Y +
                                    Actor.Transform.Right * InputManager.GetMovementAxis().X;

        moveInput = moveInput.Normalized * _CurrentSpeed;

        Vector3 finalMovement = moveInput + _FallingMovement;

        _CharacterController.Move(finalMovement * Time.DeltaTime);
    }

    private void Jump()
    {
        if(!_CharacterController.IsGrounded)
        {
            return;
        }

        _FallingMovement.Y = Mathf.Sqrt(_JumpHeight * -2 * _Gravity);
    }

    void StartSprint()
    {
        if(!_CharacterController.IsGrounded)
        {
            return;
        }

        _IsSprinting = true;
    }

    void EndSprint()
    {
        _IsSprinting = false;
    }

    void SwapSpeeds()
    {
        if (_IsSprinting)
        {
            _DesiredSpeed = _SprintSpeed;
            return;
        }

        _DesiredSpeed = _MovementSpeed;
    }

    public override void OnDisable()
    {
        InputManager.GetJump().Pressed -= Jump;
    }
}
