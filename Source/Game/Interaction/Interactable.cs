using FlaxEngine;

namespace Game;

/// <summary>
/// Interactable Script.
/// </summary>
public class Interactable : Script
{
    public virtual void Interact()
    {
        Debug.Log("RUN INTERACTION");
    }
}
