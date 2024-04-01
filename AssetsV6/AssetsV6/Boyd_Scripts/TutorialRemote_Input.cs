//TutorialRemote_Input.cs
//Courtney Boyd, Virginia State University 
//Digital Twin Project Last Updated April 1 Spring 2024

//Tells the user the last button they pressed. 
//Should be extremely needed for device outside of oculus
//This should allow the user to map the controls without leaving the 
//headset. 

using System;
using System.IO; 
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TutorialRemote_Input : MonoBehaviour
{
    public bool isModeOn; 
    public Text DummyText; //debug tool
    // Start is called before the first frame update
    
    void Start()
    {
        isModeOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ArmAsInputClicked(){

        XRControllerInput.rightprimaryButtonPressed += APressed;
        XRControllerInput.rightsecondaryButtonPressed += BPressed;
        XRControllerInput.leftprimaryButtonPressed += XPressed; 
        XRControllerInput.leftTriggerPressed += TrigPressed; 

    }
    public void TrigPressed(){
        //DummyText.text = "TrigPressed"; //Debug Tool
        isModeOn = !isModeOn; 
        DummyText.text = isModeOn.ToString();

    }
    public void APressed(){
        if (isModeOn == true){
            DummyText.text = "APressed"; //Debug Tool
        }
    }

    public void BPressed(){
        if (isModeOn ==true){
            DummyText.text = "BPressed"; //Debug Tool
        }
    }

    public void XPressed(){
        if (isModeOn ==true){
            DummyText.text = "XPressed"; //Debug Tool
        }
    }

}
