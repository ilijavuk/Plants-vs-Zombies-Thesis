using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class intro_text : MonoBehaviour
{
    public TextMeshProUGUI m_Text;
    void Start()
    {
        m_Text.enabled = false;
        StartCoroutine(tekst(5.0f));
    }


    IEnumerator tekst(float delay)
    {
        yield return new WaitForSeconds(2.0f);
        m_Text.enabled = true;
        yield return new WaitForSeconds(delay);
        m_Text.text = "BRZO POSTAVI GRAŠU DOK ZOMBIJI NISU STIGLI";
        yield return new WaitForSeconds(delay);
        m_Text.enabled = false;    
    }
}
