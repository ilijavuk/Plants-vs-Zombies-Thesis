using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float countdown;
    public float radius;
    public int damage;
    public Animator animator;

    public virtual void SetStart(bool value) { }

    void StartAnimation()
    {
        animator.SetBool("exploding", true);
    }

    public void Explode()
    {
        Collider2D[] objectsInRange = Physics2D.OverlapBoxAll(transform.position, new Vector2(radius, radius), 0);
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
