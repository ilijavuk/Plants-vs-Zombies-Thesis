using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_damage : MonoBehaviour
{

    public Animator animacija;
    private bool udaram = false;
    public int damage;
    public float cdZaUdaranje;
    private float timer;
    private GameObject go;
    
    private void Start()
    {
        animacija.SetBool("grize", false);
        timer = cdZaUdaranje;
    }
    void Udari()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            go.GetComponent<PlantsHP>().SmanjiHP(damage);
            timer = cdZaUdaranje;
        }
    }
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.tag == "Plant" && !udaram)
        {
            animacija.SetBool("grize", true);
            udaram = true;
            go = other.gameObject;
            InvokeRepeating("Udari", 0, .01667f);
        }
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Plant")
        {
            udaram = false;
            animacija.SetBool("grize", false);
            CancelInvoke();
        }

    }
}
