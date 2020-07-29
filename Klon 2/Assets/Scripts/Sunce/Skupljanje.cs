using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skupljanje : MonoBehaviour
{
	public static int valuta = 100;
    
	void OnMouseDown(){
		if(gameObject.tag == "SunceMalo"){
			valuta += 25;			
		}
		else{
			valuta += 50;
		}
		
		Destroy(gameObject);
	}
}
