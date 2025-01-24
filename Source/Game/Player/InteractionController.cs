using FlaxEngine;

namespace Game;

/// <summary>
/// InteractionController Script.
/// </summary>
public class InteractionController : Script
{
    [ShowInEditor, Serialize] LayersMask _InteractLayer;
    [ShowInEditor, Serialize] Actor _Camera;
    [ShowInEditor, Serialize] float _Reach;

    public override void OnEnable()
    {
        InputManager.GetInteract().Pressed += FindInteractable;
    }

    void FindInteractable()
    {
        if (!Physics.RayCast(_Camera.Position, _Camera.Transform.Forward, out RayCastHit hit, _Reach, _InteractLayer))
        {
            return;
        }

        hit.Collider.Parent.GetScript<Interactable>().Interact();
    }

    public override void OnDisable()
    {
        InputManager.GetInteract().Pressed -= FindInteractable;
    }
}
