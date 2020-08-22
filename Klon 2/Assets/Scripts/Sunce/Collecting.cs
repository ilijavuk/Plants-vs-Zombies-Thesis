using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
	public static int money = 100;
    public ParticleSystem em;
    public AudioSource collectingSound;
    private bool particlePlayed = false;
    
    void Update()
    {
        if ( ( particlePlayed && em && !em.isPlaying ) || !em)
        {
            float step = 8 * Time.deltaTime; // calculate distance to move
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(-6f, 3f), step);

            // Check if the position of the sun and target are approximately equal.
            if (Vector3.Distance(transform.position, new Vector2(-6f, 3f)) < 0.001f)
            {
                money += 50;
                // Destroy the gameobject.
                Destroy(gameObject);
            }
        }
    }
    
	void OnMouseDown(){

        if (em && em.isPlaying)
            em.Stop();

        if (em)
        {
            collectingSound.Play();
            var main = em.main;
            main.simulationSpeed = 4;
            em.Play();
            particlePlayed = true;
        }
	}

}
