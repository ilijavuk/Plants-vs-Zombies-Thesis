using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallnut_Script : MonoBehaviour
{
    public int thresholdForDamaged1;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PlantsHP>().HP < thresholdForDamaged1 && animator)
        {
            animator.SetInteger("DamagedLevel", 1);
        }       
    }
}
