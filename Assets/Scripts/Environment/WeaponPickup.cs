using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : Interactable
{
    public Weapon weapon;
    public Combat combat;

    public override void Action()
    {
        combat.equippedWeapon.equipped = false;
        Weapon tmp = combat.equippedWeapon;
        int ammoTmp = combat.equippedWeapon.StartAmmo;
        weapon.equipped = true;
        tmp.ammo += ammoTmp;
        combat.equippedWeapon = weapon;
        Destroy(this.gameObject);
    }
}
