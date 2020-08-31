using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileVeloc : MonoBehaviour
{
    public Vector2 SpeedVector;
    public int Damage;
    public AudioSource[] SplatSounds;

	void Start()
	{
		this.gameObject.GetComponent<Rigidbody2D>().velocity = SpeedVector;
	}

	void Update(){
		if(transform.position.x >= 5){
			Destroy(gameObject);
		}		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            SplatSounds[Random.Range(0, SplatSounds.Length)].Play();
            other.GetComponent<zombie>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
