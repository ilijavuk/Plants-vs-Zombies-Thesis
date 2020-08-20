using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryExplosion : MonoBehaviour
{
    public float countdown;
    public float radius;
    public int damage;
    public ParticleSystem em;
    private bool particlePlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", countdown);
    }

    void Explode()
    {
        if (em && em.isPlaying)
            em.Stop();

        if (em)
        {
            var main = em.main;
            main.simulationSpeed = 3;
            em.Play();
            particlePlayed = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if ((particlePlayed && em && !em.isPlaying) || !em)
        {
            
            Collider2D[] objectsInRange = Physics2D.OverlapBoxAll(transform.position, new Vector2(2.5f, 2.5f), 0);
            Debug.Log(objectsInRange.Length);
            foreach (Collider2D col in objectsInRange)
            {
                zombie script = col.GetComponent<zombie>();
                if (script)
                    script.TakeDamage(damage);
                //if (enemy != null)
                {
                    /*
                    // linear falloff of effect
                    float proximity = (transform.position - enemy.transform.position).magnitude;
                    float effect = 1 - (proximity / radius);
                    */
                    //float effect = 1;

                    //enemy.ApplyDamage(damage * effect);
                }
            }

            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Check that it is being run in Play Mode, so it doesn't try to draw this in Editor mode
        //if (m_Started)
            //Draw a cube where the OverlapBox is (positioned where your GameObject is as well as a size)
            Gizmos.DrawWireCube(transform.position, new Vector3(2.5f, 2.5f, 0));
    }
}

