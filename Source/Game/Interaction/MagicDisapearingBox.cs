using FlaxEngine;

namespace Game;

/// <summary>
/// MagicDisapearingBox Script.
/// </summary>
public class MagicDisapearingBox : Interactable
{
    public override void Interact()
    {
        Destroy(Actor);
    }
}
