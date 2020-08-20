using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skupljanje : MonoBehaviour
{
	public static int valuta = 100;
    public ParticleSystem em;
    private bool particlePlayed = false;
    
    void Update()
    {
        if ( ( particlePlayed && em && !em.isPlaying ) || !em)
            Destroy(gameObject);
    }
    
	void OnMouseDown(){
		valuta += 50;

        if (em && em.isPlaying)
            em.Stop();

        if (em)
        {
            var main = em.main;
            main.simulationSpeed = 4;
            em.Play();
            particlePlayed = true;
        }
        
	}
}
