using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryExplosion : MonoBehaviour
{
    public float countdown;
    public float radius;
    public int damage;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartAnimation", countdown);
    }

    void StartAnimation()
    {
        animator.SetBool("exploding", true);
    }

    void Explode()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapBoxAll(transform.position, new Vector2(2.5f, 2.5f), 0);
        foreach (Collider2D col in objectsInRange)
        {
            zombie script = col.GetComponent<zombie>();
            if (script)
                script.TakeDamage(damage);
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

