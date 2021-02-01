using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingTest : Interactable
{
    public override void Action()
    {
        Destroy(this.gameObject);
        Debug.Log("ouch, mi hai toccato");
    }
}
