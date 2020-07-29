using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class progressBar : MonoBehaviour
{
    public Slider bar;
    public int brojZombija;
    private float var;
    
    private void Start()
    {
        Counter.brojZombija = brojZombija;
        Counter.value = 0;
        bar = GetComponent<Slider>();   
        var = 1.0f/brojZombija;
    }
    void Update()
    {
        bar.value = Counter.value*var;
    }
}
