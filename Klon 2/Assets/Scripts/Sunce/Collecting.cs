using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : MonoBehaviour
{
	public static int money = 150;
    public ParticleSystem popParticleAnim;
    public AudioSource collectingSound;
    private bool collected = false;
    
    void Update()
    {
        if (collected)
        {
            float step = 8 * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(-5.250315f, 3.1f), step);

            if (Vector3.Distance(transform.position, new Vector2(-5.250315f, 3.1f)) < 0.001f)
            {
                money += 50;
                Destroy(gameObject);
            }
        }
    }
    
	void OnMouseDown(){

        if (popParticleAnim && popParticleAnim.isPlaying)
            popParticleAnim.Stop();

        if (popParticleAnim)
        {
            collectingSound.Play();
            var main = popParticleAnim.main;
            main.simulationSpeed = 4;
            popParticleAnim.Play();
        }
        collected = true;
    }

}
