using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Interactable
{
    public int healthBoost;
    public Player player;

    public override void Action()
    {
        player.hp = player.hp + healthBoost;
        player.hp = Mathf.Clamp(player.hp, 0, player.HpTot);
        Debug.Log(player.hp);
        Destroy(this.gameObject);
    }
}
