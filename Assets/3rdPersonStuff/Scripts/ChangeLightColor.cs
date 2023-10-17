using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color newColor;

   //gets light component for new color
   //Also adds more intensity so it can be seen while on with all the neon
    public void ChangeColor()
    {
        GetComponent<Light>().color = newColor;
        GetComponent<Light>().intensity = 40000000;
    }
    //makes color go back "off"
    public void ChangleColorBack()
    {
        GetComponent<Light>().color = Color.black;
        GetComponent<Light>().intensity = 0;
    }
}
