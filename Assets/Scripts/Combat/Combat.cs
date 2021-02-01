using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Weapon equippedWeapon;

    private Weapon defaultWeapon;

    private void Start()
    {
        defaultWeapon = equippedWeapon;
    }

    private void Update()
    {
        if(equippedWeapon.ammo == 0)
        {
            equippedWeapon.equipped = false;
            Weapon tmp = equippedWeapon;
            int ammoTmp = equippedWeapon.StartAmmo;
            equippedWeapon = defaultWeapon;
            equippedWeapon.equipped = true;
            tmp.ammo = ammoTmp;
        }
    }

    public void Fight()
    {
        equippedWeapon.Hit();
    }
}
