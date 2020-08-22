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
            Destroy(gameObject);
    }
    
	void OnMouseDown(){
        money += 50;

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
