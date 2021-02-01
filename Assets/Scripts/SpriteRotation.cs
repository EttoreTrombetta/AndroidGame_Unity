using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotation : MonoBehaviour
{
    public Transform player;
    public Transform sprite;

    void Start()
    {
        
    }

    void Update()
    {
        sprite.LookAt(player);
    }
}
