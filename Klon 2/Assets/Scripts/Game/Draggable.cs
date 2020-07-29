using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class Draggable : MonoBehaviour
{
	public static bool drag_ready;
	public static bool being_dragged;
	
	void Start(){
		drag_ready = false;
		being_dragged = false;
		//Event novi_event = Event.current;
	}
	void OnGUI(){
		Event novi_event = Event.current;
		if(Event.current.type == EventType.MouseDown){
			drag_ready = true;
		}
		if(Event.current.type == EventType.MouseUp){
			drag_ready = false;
		}
		if(Event.current.type == EventType.MouseDrag){
			being_dragged = true;
			
			// Clear out drag data
            DragAndDrop.PrepareStartDrag();

            // Set up what we want to drag
           // DragAndDrop.objectReferences = gameObject;

            // Start the actual drag
            DragAndDrop.StartDrag("Dragging prefab");			
		}
		
	}
	
	
   /*  void Start()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
		//dodajemo vrstu eventa "Drag"
        entry.eventID = EventTriggerType.Drag;
		//pozovi OnDragDelegate 
        entry.callback.AddListener((data) => { OnDragDelegate((PointerEventData)data); });
        trigger.triggers.Add(entry);
    }

    public void OnDragDelegate(PointerEventData data)
    {
        //Create a ray going from the camera through the mouse position
        Ray ray = Camera.main.ScreenPointToRay(data.position);
        //Calculate the distance between the Camera and the GameObject, and go this distance along the ray
        Vector3 rayPoint = ray.GetPoint(Vector3.Distance(transform.position, Camera.main.transform.position));
        //Move the GameObject when you drag it
        transform.position = rayPoint;
    } */
}
