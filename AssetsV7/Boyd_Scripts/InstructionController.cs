using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject LearnMovingText; 
    public GameObject LearnModesText; 
    public GameObject LearnButtonText; 
    public GameObject LearnButton2Text; 
    public GameObject LearnAAOText;
    public int myCounter;  

    void Start()
    {
        myCounter = 0; 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ContinueButtonHandler(){
        myCounter = myCounter+1; 
        switch(myCounter)
            {
                case 1:
                    LearnMovingText.SetActive(false); 
                    LearnModesText.SetActive(true); 
                break;

                case 2:
                    LearnModesText.SetActive(false); 
                    LearnButtonText.SetActive(true); 
                break;

                case 3:
                    LearnButtonText.SetActive(false); 
                    LearnButton2Text.SetActive(true);
                break;

                case 4:
                    LearnButton2Text.SetActive(false); 
                    LearnAAOText.SetActive(true); 
                break;

                default:
                //Do Nothing 
                break;

            }
    }

}
