using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
	public Vector2 DropSpeed;
	private float positionY;

	void Start()
	{
        positionY = Random.Range(-2, 2);	
		this.gameObject.GetComponent<Rigidbody2D>().velocity = DropSpeed;
	}
	
    // Update is called once per frame
    void Update()
    {
		//ako dođe do određene trave, zaustavi se
		if(transform.position.y <= positionY)
        {
			this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
		}
    }
}
