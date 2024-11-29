using FlaxEngine;

namespace Game;

/// <summary>
/// CameraController Script.
/// </summary>
public class CameraController : Script
{
    Actor _Player;

    [Header("LOOK")]
    [ShowInEditor, Serialize] float _MouseSense;
    [ShowInEditor, Serialize] float _MaxLookUp;
    [ShowInEditor, Serialize] float _YFollowOffset;

    Vector2 _Rotation;

    public override void OnStart()
    {
        _Player = Level.FindActor("Player");

        Screen.CursorLock = CursorLockMode.Locked;
        Screen.CursorVisible = false;
    }

    public override void OnUpdate()
    {
        Actor.Position = new Vector3(_Player.Position.X,
                                    _Player.Position.Y + _YFollowOffset,
                                    _Player.Position.Z);

        float mouseX = InputManager.GetMouseAxis().X;
        float mouseY = InputManager.GetMouseAxis().Y;

        _Rotation.Y += mouseX * _MouseSense * Time.DeltaTime;
        _Rotation.X += mouseY * _MouseSense * Time.DeltaTime;

        _Rotation.X = Mathf.Clamp(_Rotation.X, -_MaxLookUp, _MaxLookUp);

        Actor.EulerAngles = new Vector3(_Rotation.X, _Rotation.Y, 0);
        _Player.EulerAngles = new Vector3(0, _Rotation.Y, 0);
    }
}
