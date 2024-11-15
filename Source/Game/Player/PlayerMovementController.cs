using FlaxEngine;

namespace Game;

/// <summary>
/// PlayerMovementController Script.
/// </summary>
public class PlayerMovementController : Script
{
    public override void OnUpdate()
    {
        Debug.Log(InputManager.GetMovementAxis());
    }
}
