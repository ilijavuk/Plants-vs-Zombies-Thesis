using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class spawnItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	private bool isBeingHeld = false;
	public GameObject prefab;
	private GameObject go;
    public int cijena;
	
    Vector3 MousePos()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        //convert iz screena u veličinu ekrana
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
	void Update(){
        Vector3 mousePos = MousePos();
			
	    if(isBeingHeld == true){
			go.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
		}
	}
	
    //uzimanje
	public void OnPointerDown(PointerEventData eventData){
		if(Input.GetMouseButtonDown(0) && Skupljanje.valuta >= cijena){
            Vector3 mousePos = MousePos();

            //instantizacija objekta
            go = (GameObject)Instantiate(prefab, new Vector3(mousePos.x, mousePos.y, 0),Quaternion.identity);
		
			isBeingHeld = true;
		}
	}
	
    //ostavljanje
	public void OnPointerUp(PointerEventData eventData){
        Vector3 mousePos = MousePos();
        if (isBeingHeld){
			Skupljanje.valuta -= cijena;
			isBeingHeld = false;
			//convert iz screena u veličinu ekrana
			go.transform.localPosition = new Vector3(Mathf.Round(mousePos.x ), Mathf.Round(mousePos.y), 0);
		}
        if(go.tag == "Plant")
        {
            Collider2D col = go.GetComponent<CircleCollider2D>();
            col.isTrigger = false;
            Collider2D col2 = go.GetComponent<BoxCollider2D>();
            col2.enabled  = true;
        }
        
    }
}
