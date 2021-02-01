using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleDeath : MonoBehaviour
{
    public float life;

    private void Update()
    {
        life -= Time.deltaTime;

        //Debug.Log(life);

        if(life <= 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
