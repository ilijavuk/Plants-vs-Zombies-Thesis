using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polevaulter : MonoBehaviour
{
    public BoxCollider2D Collider;
    public int Damage;
    Animator animator;
    zombie zombieScript;
    GameObject vaultedPlant = null;
    GameObject targetPlant;

    private void Start()
    {
        animator = GetComponent<Animator>();
        zombieScript = GetComponent<zombie>();
        transform.position = new Vector2(transform.position.x, transform.position.y + 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Plant")
        {
            if(vaultedPlant == null)
            {
                vaultedPlant = collision.gameObject;
                animator.SetBool("IsVaulting", true);
            }
            if (collision.gameObject != vaultedPlant)
            {
                animator.SetBool("IsBiting", true);
                targetPlant = collision.gameObject;
                InvokeRepeating("DoDamage", 1f, 1f);
            }
        }
    }

    void DoDamage(){
        if(targetPlant)
            targetPlant.GetComponent<PlantsHP>().SmanjiHP(Damage);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant" && animator.GetBool("IsBiting") == true )
        {
            animator.SetBool("IsBiting", false);
            CancelInvoke();
        }
    }

    public void SetSpeed(float setSpeed) { 
        zombieScript.varijabla.x = -1/setSpeed;
    }

    public void ResetSpeed()
    {
        animator.SetBool("IsVaulting", false);
        zombieScript.varijabla.x = -1/4.7f;
        Collider.enabled = true;
    }
}
