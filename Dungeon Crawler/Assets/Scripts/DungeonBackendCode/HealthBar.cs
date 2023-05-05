using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour 
{
    public GameObject one, two, three, four, five, six, seven, eight, nine, ten;
    public bool oneOn, twoOn, threeOn, fourOn, fiveOn, sixOn, sevenOn, eightOn, nineOn, tenOn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fillBar();
        if(Inhabitant.getHP() < Inhabitant.getHP * 0.9)
        {
            tenOn = false;
            nineOn = false;
        }

    }
    private void fillBar()
    {
        oneOn = true;
        twoOn = true;
        threeOn = true;
        fourOn = true;
        fiveOn = true;
        sixOn = true;
        sevenOn = true;
        eightOn = true;
        nineOn = true;
        tenOn = true;
    }
}
