using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
	public Vector2 varijabla;
	public float pozicijay;

	void Start()
	{
		pozicijay = Random.Range(-2, 2);	
		this.gameObject.GetComponent<Rigidbody2D>().velocity = varijabla;
	}
	
    // Update is called once per frame
    void Update()
    {
		//ako dođe do određene trave, zaustavi se
		if(transform.position.y <= pozicijay){
			this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
    }
}
