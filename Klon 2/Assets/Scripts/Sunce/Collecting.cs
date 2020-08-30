using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collecting : MonoBehaviour
{
	public static int money = 50;
    public ParticleSystem popParticleAnim;
    public AudioSource collectingSound;
    private bool collected = false;
    private Vector2 targetPosition;


    void Update()
    {
        if (collected)
        {
            float step = 8 * Time.deltaTime; 
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) < 2f)
            {
                money += 25;
                Destroy(gameObject);
            }
        }
    }
    
	void OnMouseDown(){
        if (popParticleAnim)
        {
            collectingSound.Play();
            popParticleAnim.Play();
        }
        targetPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0));
        collected = true;
    }

}
