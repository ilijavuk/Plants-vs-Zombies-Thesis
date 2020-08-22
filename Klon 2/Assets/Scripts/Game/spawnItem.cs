using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class spawnItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int price;
	public GameObject prefab;
    private bool isBeingHeld = false;
	private GameObject go;
    private bool clickFlag;

    //uzimanje
    public void OnPointerDown(PointerEventData eventData)
    {
        if (isBeingHeld == true)
        {
            Destroy(go);
            isBeingHeld = false;
        }
        else
        {
            clickFlag = true;
            TakeIt();
        }
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        clickFlag = false;
    }

    Vector3 MousePos()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        //convert iz screena u veličinu ekrana
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        return mousePos;
    }

    void Start()
    {
        transform.GetChild(0).GetComponent<Text>().text = price.ToString();
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

    private void TakeIt()
    {
        Vector3 mousePos = MousePos();
        if (isBeingHeld == false && Collecting.money >= price)
        {
            //instantizacija objekta
            go = (GameObject)Instantiate(prefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            Animation goAnimation = go.GetComponent<Animation>();
            if (goAnimation)
                goAnimation.enabled = false;
            isBeingHeld = true;
        }
    }
    
    private void LeaveIt()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hits.Length != 0 && hits[0].collider != null)
        {
            int plantCount = 0;
            bool foundEmptySpot = false;

            foreach (var item in hits)
            {
                if (item.collider.gameObject.tag == "Ground")
                    foundEmptySpot = true;
                else if ((item.collider.gameObject.tag == "TakenGround"))
                    plantCount++;
            }
            Debug.Log(plantCount);
            if(foundEmptySpot && plantCount == 1)
            {
                Vector3 mousePos = MousePos();
                Collecting.money -= price;
                isBeingHeld = false;
                //convert iz screena u veličinu ekrana
                go.transform.localPosition = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0);
                Collider2D col = go.GetComponent<CircleCollider2D>();
                col.isTrigger = false;
                go.SendMessage("SetStart", true);
            }
        }
    }
}
