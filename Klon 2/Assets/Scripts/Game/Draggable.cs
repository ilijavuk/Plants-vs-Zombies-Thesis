using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEditor;

public class Draggable : MonoBehaviour
{
    /*
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
    */
}
