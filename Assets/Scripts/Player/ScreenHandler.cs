using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenHandler : MonoBehaviour
{
    public float margin;
    public Camera mainCam;
    public InteractionManager im;
    public EndLevel el;

    private Rect camRect;

    void Start()
    {
        camRect = Camera.main.rect;

        float mx = margin / Screen.width;
        float my = margin / Screen.height;

        camRect.min = new Vector2(mx, 1.5f - (((camRect.xMax - camRect.xMin) - mx) + my));
        camRect.max = new Vector2(1f - mx, 1f - my);
        
        Camera.main.rect = camRect;
        im.TouchArea = camRect;

        Debug.Log("min" + camRect.min.x * Screen.width + " ; " + camRect.min.y * Screen.height + " - max:" + camRect.max.x * Screen.width + " ; " + camRect.max.y * Screen.height);
    }

    void Update()
    {
        if(el.Gameover)
        {
            mainCam.depth = -2;
            Time.timeScale = 0;
        }
    }
}
