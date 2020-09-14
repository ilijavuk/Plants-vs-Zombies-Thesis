using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class spawnItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int price;
	public GameObject prefab;
    public AudioScript SoundEffects;
    public Image DisabledOverlay;
    public float plantCooldown;
    private float counter;
	private GameObject go;
    private bool clickFlag;
    private bool available = true;

    //uzimanje
    public void OnPointerDown(PointerEventData eventData)
    {
        SoundEffects.PlaySound(1);
        if(Shovel.toggledOn == true)
        {
            return;
        }
        else if (CarryingPlant.IsCarrying == true && go != null)
        {
            Destroy(go);
            CarryingPlant.IsCarrying = false;
        }
        else if(CarryingPlant.IsCarrying == true && go == null)
        {
            SoundEffects.PlaySound(0);
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
    
	void Update(){
        if (UnityEngine.Input.GetMouseButton(0))
        {
            if(CarryingPlant.IsCarrying && clickFlag == false && go != null)
            LeaveIt();
        }
	    if(CarryingPlant.IsCarrying == true && go != null){
            Vector3 mousePos = MousePos();
            go.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
		}
	}

    private void TakeIt()
    {
        Vector3 mousePos = MousePos();
        if (CarryingPlant.IsCarrying == false && Collecting.money >= price && available == true)
        {
            //instantizacija objekta
            go = (GameObject)Instantiate(prefab, new Vector3(mousePos.x, mousePos.y, 0), Quaternion.identity);
            Animation goAnimation = go.GetComponent<Animation>();
            if (goAnimation)
                goAnimation.enabled = false;
            CarryingPlant.IsCarrying = true;
        }
        else
        {
            SoundEffects.PlaySound(0);
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
            if(foundEmptySpot && plantCount == 1)
            {
                Vector3 mousePos = MousePos();
                Collecting.money -= price;
                CarryingPlant.IsCarrying = false;
                //convert iz screena u veličinu ekrana
                go.transform.localPosition = new Vector3(Mathf.Round(mousePos.x), Mathf.Round(mousePos.y), 0);
                Collider2D col = go.GetComponent<CircleCollider2D>();
                col.isTrigger = false;
                go.SendMessage("SetStart", true);
                SoundEffects.PlaySound(Random.Range(2, 4));
                go = null;
                DisabledOverlay.transform.localScale = new Vector2(1f, 1f);
                counter = plantCooldown;
                available = false;
                InvokeRepeating("startUnlocking", 0, 0.01f);
            }
        }
    }

    void startUnlocking()
    {
        if(counter > 0)
        {
            DisabledOverlay.transform.localScale = new Vector2(1f, counter/plantCooldown);
            counter -= 0.01f;
        }
        else
        {
            DisabledOverlay.transform.localScale = new Vector3(1f, 0f);
            counter = plantCooldown; 
            CancelInvoke();
            available = true;
        }
    }
}
