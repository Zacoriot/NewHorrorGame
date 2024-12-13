using FlaxEngine;

namespace Game;

/// <summary>
/// PlayerMovementController Script.
/// </summary>
public class PlayerMovementController : Script
{
    CharacterController _CharacterController;

    [Header("==MOVEMENT==")]
    [ShowInEditor, Serialize] float _MovementSpeed;
    Vector3 _FallingMovement;

    [Header("==JUMP==")]
    [ShowInEditor, Serialize] float _JumpHeight;

    float _Gravity;

    public override void OnEnable()
    {
        InputManager.GetJump().Pressed += Jump;
    }

    public override void OnStart()
    {
        _CharacterController = (CharacterController)Actor;

        _Gravity = Physics.Gravity.Y;
    }

    public override void OnUpdate()
    {
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

        moveInput = moveInput.Normalized * _MovementSpeed;

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

    public override void OnDisable()
    {
        InputManager.GetJump().Pressed -= Jump;
    }
}
