using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public string weaponName;
    public int damage;
    public int range;
    public int ammo;
    public float fireRate;

    public Transform origin;
    public Text txtAmmo;

    public bool equipped = false;

    //public Sprite sprite;
    //public AudioSource noise;

    private float cooldown;
    private int startAmmo;

    public int StartAmmo { get => startAmmo; set => startAmmo = value; }

    private void Start()
    {
        cooldown = 0f;
        StartAmmo = ammo;
    }

    private void Update()
    {
        if(ammo < 0)
        {
            ammo = -1;
        }

        if(cooldown > 0f)
        {
            cooldown -= Time.deltaTime;
            //Debug.Log(cooldown);
        }

        if(ammo != -1 && equipped)
        {
            txtAmmo.text = ammo.ToString();
        }

        if (ammo == -1 && equipped)
        {
            //txtAmmo.text = "∞";
            txtAmmo.text = "inf";
        }
    }

    public void Hit()
    {
        if(cooldown <= 0f)
        {
            if(ammo != -1 && ammo > 0)
            {
                ammo--;
            }

            if((ammo > 0 || ammo == -1))
            {
                //noise.Play();
                RaycastHit hit;

                if (Physics.Raycast(origin.position, origin.forward, out hit, range) && hit.collider.tag == "Enemy")
                {
                    hit.collider.GetComponent<Enemy>().hp -= damage;
                    Instantiate(hit.collider.GetComponent<Enemy>().hitFeedback, hit.collider.GetComponent<Enemy>().sprite.transform.position, hit.collider.GetComponent<Enemy>().sprite.transform.rotation);
                    //Debug.Log(hit.collider.GetComponent<Enemy>().hp);
                    //Debug.Log("uccisione eterna");
                }
                //Debug.Log("FIRE!");
                cooldown = fireRate;
            }
        }
    }
}
