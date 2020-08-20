using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjektilVeloc : MonoBehaviour
{
    public Vector2 varijabla;
    public int damage;
	void Start()
	{
		this.gameObject.GetComponent<Rigidbody2D>().velocity = varijabla;
	}

	void Update(){
		if(transform.position.x >= 6){
			Destroy(gameObject);
		}		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            other.GetComponent<zombie>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
