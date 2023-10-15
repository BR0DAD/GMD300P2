using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CanvasUpdate : MonoBehaviour
{

    public TMP_Text CollectibleText;
    public MyManager MyManager;

    //finds game manager so whenever the scene resets it attatches a manager properly to the canvas
    public void Start()
    {
        MyManager = GameObject.FindGameObjectWithTag("Manager").GetComponent<MyManager>();
    }
    // Update is called once per frame
    void Update()
    {
        CollectibleText.text = MyManager.playerScore.ToString();
        
    }
}
