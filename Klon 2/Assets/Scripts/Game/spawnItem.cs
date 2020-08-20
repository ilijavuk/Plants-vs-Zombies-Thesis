using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class spawnItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int cijena;
	public GameObject prefab;
    private bool isBeingHeld = false;
	private GameObject go;
    private bool clickFlag;

    Vector3 MousePos()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        //convert iz screena u veličinu ekrana
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }
	void Update(){
        if (UnityEngine.Input.GetMouseButton(0))
        {
            if(isBeingHeld && clickFlag == false)
            LeaveIt();
        }
	    if(isBeingHeld == true){
            Vector3 mousePos = MousePos();
            go.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
		}
	}
	
    //uzimanje
	public void OnPointerDown(PointerEventData eventData){
        clickFlag = true;
        TakeIt();
	}
    public void OnPointerUp(PointerEventData eventData)
    {
        clickFlag = false;
    }
    private void TakeIt()
    {
        Vector3 mousePos = MousePos();
        if (isBeingHeld == false && Skupljanje.valuta >= cijena)
        {
            //instantizacija objekta
            go = (GameObject)Instantiate(prefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            isBeingHeld = true;
        }
    }
    
    private void LeaveIt()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hits.Length != 0 && hits[0].collider != null)
        {
            int plantCount = -1;
            bool foundEmptySpot = false;

            foreach (var item in hits)
            {
                if (item.collider.gameObject.tag == "Ground")
                    foundEmptySpot = true;
                else if ((item.collider.gameObject.tag == "Plant" || item.collider.gameObject.tag == "InvisPlant") && !(item.collider is BoxCollider2D))
                    plantCount++;
            }
            Debug.Log($"Plant count: {plantCount}");
            if(foundEmptySpot && plantCount == 0)
            {
                Vector3 mousePos = MousePos();
                Skupljanje.valuta -= cijena;
                isBeingHeld = false;
                //convert iz screena u veličinu ekrana
                go.transform.localPosition = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0);
                Collider2D col = go.GetComponent<CircleCollider2D>();
                col.isTrigger = false;
                Collider2D col2 = go.GetComponent<BoxCollider2D>();
                col2.enabled = true;
            }
        }
    }
}
