using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLightColor : MonoBehaviour
{
    public Color newColor;

   //gets light component for new color
    public void ChangeColor()
    {
        GetComponent<Light>().color = newColor;
    }
    //makes color go back "off"
    public void ChangleColorBack()
    {
        GetComponent<Light>().color = Color.black;
    }
}
