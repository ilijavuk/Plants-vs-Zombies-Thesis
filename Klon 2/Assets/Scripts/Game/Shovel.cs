using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{
    public Texture2D shovelTexture;
    public static bool toggledOn = false;
    GameObject hoveredObject = null;

    void Update()
    {
        if (toggledOn == true)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            bool plantHit = false;
            if (hits.Length != 0)
            {
                foreach(var hit in hits)
                {
                    if(hit.collider.gameObject.tag == "Plant" && hit.collider.GetType() == typeof(CircleCollider2D))
                    {
                        plantHit = true;
                        if(hit.collider.gameObject != hoveredObject)
                        {
                            if(hoveredObject != null)
                                hoveredObject.SendMessage("WhenMouseExit");
                            hoveredObject = hit.collider.gameObject;
                            hoveredObject.SendMessage("WhenMouseEnter");
                            Debug.Log(hoveredObject);
                            break;
                        }
                    }
                }
            }
            if (!plantHit)
            {
                hoveredObject.SendMessage("WhenMouseExit");
                hoveredObject = null;
            }
            if (Input.GetMouseButtonDown(0) && hoveredObject != null)
                hoveredObject.SendMessage("WhenMouseDown");
        }

    }

    public void ChangeCursor()
    {
        if (!toggledOn && CarryingPlant.IsCarrying == false)
        {
            Cursor.SetCursor(shovelTexture, Vector2.zero, CursorMode.Auto);
        }
        else{
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
            hoveredObject = null;
        }
        toggledOn = !toggledOn;
    }
}
