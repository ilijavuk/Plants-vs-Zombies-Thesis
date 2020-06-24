using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantsHP : MonoBehaviour
{
    public int HP;

    public void SmanjiHP(int dmg)
    {
        HP -= dmg;
        Debug.Log(dmg);
        if (HP <= 0)
        {
            StartCoroutine(unisti());
        }
    }
    IEnumerator unisti()
    {
        transform.position = new Vector3(11, 0, 0);
        yield return 0; // skippaj jedan frame
        Destroy(gameObject);
    }
}
