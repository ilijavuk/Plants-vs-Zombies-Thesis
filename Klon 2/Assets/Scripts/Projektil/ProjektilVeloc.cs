using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilVeloc : MonoBehaviour
{
    public Vector2 varijabla;
	void Start()
	{
		this.gameObject.GetComponent<Rigidbody2D>().velocity = varijabla;
	}
	void Update(){
		if(transform.position.x >= 10){
			Destroy(gameObject);
		}		
	}
}
