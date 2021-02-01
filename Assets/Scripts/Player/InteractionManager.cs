using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    public Camera mainCam;
    public float interactionRange = 7f;

    public Rect TouchArea { get => touchArea; set => touchArea = value; }

    private Rect touchArea = Rect.zero;

    void Start()
    {
        
    }

    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            Vector2 touchPos = new Vector2(touch.position.x / Screen.width, touch.position.y / Screen.height);
            if(touchArea.Contains(touchPos))
            {
                if (touch.phase == TouchPhase.Began)
                {
                    RaycastHit hit;
                    Ray ray = mainCam.ScreenPointToRay(touch.position);

                    if (Physics.Raycast(ray.origin, ray.direction, out hit, interactionRange) && hit.collider.tag == "Interactable")
                    {
                        hit.collider.gameObject.SendMessageUpwards("Action");
                    }
                }
            }
        }
    }
}
