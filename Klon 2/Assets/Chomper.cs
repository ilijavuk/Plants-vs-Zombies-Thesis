using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chomper : MonoBehaviour
{
    public int Damage;
    public int Cooldown;
    private Animator Anim;
    private GameObject BitingTarget = null;
    private BoxCollider2D BoxCollider;
    private bool Biting = false;
    // Start is called before the first frame update
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        BoxCollider = gameObject.GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie" && !Biting)
        {
            Biting = true;
            BitingTarget = other.gameObject;
            Anim.SetBool("biting", true);
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Zombie")
        {
            
            if(Anim.GetBool("chewing") == false)
            {

                Biting = false;
            }
        }
    }

    void DoDamage()
    {
        Debug.Log("Grizem");
        if (BitingTarget)
            BitingTarget.GetComponent<zombie>().TakeDamage(Damage);
        if(!BitingTarget)
        {
            StartChewing();
        }
    }


    void StartChewing()
    {
        Anim.SetBool("chewing", true);
        Invoke("DoneChewing", Cooldown);
    }

    void DoneChewing()
    {
        Anim.SetBool("biting", false);
        Anim.SetBool("chewing", false);
        Biting = false;
    }

    void SetStart(bool value)
    {
        gameObject.GetComponent<Animator>().Play("Chomper_Idle");
        Vector3 oldPosition = transform.position;
        transform.position = new Vector3(oldPosition.x - 0.5f, oldPosition.y - 0.5f, 0);
    }
}
