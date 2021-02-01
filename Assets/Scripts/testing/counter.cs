using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class counter : MonoBehaviour
{
    public Text t;

    private int c = 0;

    public void Start()
    {
        t.text = c.ToString();
    }

    public void Count()
    {
        c++;
        t.text = c.ToString();
    }
}
