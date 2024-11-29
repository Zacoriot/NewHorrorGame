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
    static InputAxis _MouseX;
    static InputAxis _MouseY;

    // INPUT ACTIONS

    public override void OnAwake()
    {
        // INPUT AXIS
        _VerticalMovementAxis = new InputAxis("Vertical");
        _HorizontalMovementAxis = new InputAxis("Horizontal");
        _MouseX = new InputAxis("Mouse X");
        _MouseY = new InputAxis("Mouse Y");

        // INPUT ACTIONS
    }

    public override void OnDestroy()
    {
        // INPUT AXIS
        _VerticalMovementAxis.Dispose();
        _HorizontalMovementAxis.Dispose();
        _MouseX.Dispose();
        _MouseY.Dispose();

        // INPUT ACTIONS
    }

    // GETTERS
    public static Vector2 GetMovementAxis()
    {
        return new Vector2(_HorizontalMovementAxis.ValueRaw, _VerticalMovementAxis.ValueRaw);
    }

    public static Vector2 GetMouseAxis()
    {
        return new Vector2(_MouseX.ValueRaw, _MouseY.ValueRaw);
    }
}
