//TutorialRemote_Output.cs
//Courtney Boyd, Virginia State University 
//Digital Twin Project Last Updated April 1 2024

//Tells the user the last button they pressed. 
//Should be extremely needed for device outside of oculus
//This should allow the user to map the controls without leaving the 
//headset. 

using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.ComponentModel.Design.Serialization;

public class TutorialRemote_Output : MonoBehaviour
{

    public bool isModeOn; 

    public Text DummyText; //debug tool
    void Start()
    {
        isModeOn = false; 


    }
    void Update()
    {
        
    }


    public void ArmAsOutputClicked(){
        XRControllerInput.leftprimaryButtonPressed += XPressed; 
        XRControllerInput.leftsecondaryButtonPressed += YPressed; 

        XRControllerInput.rightprimaryButtonPressed += APressed; 
        XRControllerInput.rightsecondaryButtonPressed += BPressed;

        XRControllerInput.leftGripButtonPressed += LeftGripPressed; 
        XRControllerInput.leftTriggerPressed += LeftTriggerPressed; 

        XRControllerInput.rightGripButtonPressed += RightGripPressed; 
        XRControllerInput.rightTriggerPressed += RightTriggerPressed; 

        XRControllerInput.leftMenuButtonPressed += MenuPressed; 
    }

    public void MenuPressed(){
        isModeOn = !isModeOn; 
        DummyText.text = isModeOn.ToString();
        
    }
    public void XPressed(){ //INCREASE SERVO 6 POSITION VALUE

    if(isModeOn == true){
        DummyText.text = "XPressed"; //Debug Tool
        }
    }
    public void YPressed(){ //Decrease Servo 6 POSITION VALUE
    if(isModeOn == true){
        DummyText.text = "YPressed";//Debug Tool
       }
    }
    public void BPressed(){ //INCREASE SERVO 5 POSITION VALUE 
    if(isModeOn == true){ 
        DummyText.text = "BPressed";//Debug Tool
    }
    }
    public void APressed(){ //DECREASE SERVO 6 POSITION VALUE
    if(isModeOn == true){
        DummyText.text = "APressed";//Debug Tool
    }
    }

    public void LeftGripPressed(){ // INCREASE SERVO 4 POSITION VALUE
    if(isModeOn == true){
        DummyText.text = "LeftGripPressed";//Debug Tool
    }
    }

    public void LeftTriggerPressed(){ //Decrease servo 4 position value 
    if(isModeOn == true){
        DummyText.text = "LeftTriggerPressed";//Debug Tool
    }
    }

    public void RightGripPressed(){ //increase servo 3 position value 
    if(isModeOn == true){
        DummyText.text = "RightGripPressed"; //Debug Tool
    }
    }

    public void RightTriggerPressed(){ //decrease servo 3 position value 
    if(isModeOn == true){
        DummyText.text = "RightTriggerPressed"; //Debug Tool

    }
    }
}
