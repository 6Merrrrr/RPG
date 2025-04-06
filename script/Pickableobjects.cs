using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickableobjects : Interactableobject
{
    protected override void Interact()
    {
        print("Interacting with Pickable Object.");
    }
}
