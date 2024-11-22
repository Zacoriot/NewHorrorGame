using FlaxEngine;

namespace Game;

/// <summary>
/// PlayerMovementController Script.
/// </summary>
public class PlayerMovementController : Script
{
    [Header("==MOVEMENT==")]
    CharacterController _CharacterController;
    [ShowInEditor, Serialize] float _MovementSpeed;
    float _FallingSpeed;

    float _Gravity;

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
            _FallingSpeed += _Gravity * Time.DeltaTime;
        }

        Vector3 moveInput = Actor.Transform.Forward * InputManager.GetMovementAxis().Y +
                                    Actor.Transform.Right * InputManager.GetMovementAxis().X;

        moveInput = moveInput.Normalized * _MovementSpeed;

        Vector3 finalMovement = moveInput + new Vector3(0, _FallingSpeed, 0);

        _CharacterController.Move(finalMovement * Time.DeltaTime);
    }
}
