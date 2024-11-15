using FlaxEngine;

namespace Game;

/// <summary>
/// InputManager Script.
/// </summary>
public class InputManager : Script
{
    // INPUT AXIS
    static InputAxis _VerticalMovementAxis;
    static InputAxis _HorizontalMovementAxis;

    // INPUT ACTIONS

    public override void OnAwake()
    {
        // INPUT AXIS
        _VerticalMovementAxis = new InputAxis("Vertical");
        _HorizontalMovementAxis = new InputAxis("Horizontal");

        // INPUT ACTIONS
    }

    // GETTERS
    public static Vector2 GetMovementAxis()
    {
        return new Vector2(_HorizontalMovementAxis.ValueRaw, _VerticalMovementAxis.ValueRaw);
    }
}
