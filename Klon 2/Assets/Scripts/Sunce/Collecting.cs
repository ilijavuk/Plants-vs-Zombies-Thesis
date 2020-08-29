using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{
	public static int money = 150;
    public ParticleSystem popParticleAnim;
    public AudioSource collectingSound;
    public GameObject Target;
    private bool collected = false;
    
    void Update()
    {
        Vector2 targetPosition = Camera.main.ScreenToViewportPoint(new Vector2(30, Camera.main.pixelHeight-80));
        
        if (collected)
        {
            float step = 8 * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, new Vector2(30, -80), step);

            if (Vector3.Distance(transform.position, new Vector2(30, -80)) < 0.001f)
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
