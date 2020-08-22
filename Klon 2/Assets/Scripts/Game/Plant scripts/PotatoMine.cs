using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMine : Explosion
{
    public Sprite notArmedSprite;
    public BoxCollider2D blastTrigger;

    public override void SetStart(bool value)
    {
        animator.SetBool("IsSpawned", true);
        blastTrigger.enabled = true;
        blastTrigger.size = new Vector2(radius, radius);
        Invoke("StartArming", countdown);
    }

    void StartArming()
    {
        animator.Play("Potato Mine Armed");
        blastTrigger.enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            animator.SetBool("exploding", true);
        }
    }
}
