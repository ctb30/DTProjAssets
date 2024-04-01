//EnvironmentManager.cs
//Courtney Boyd, Virginia State University 
//Digital Twin Project Last Updated April 1 Spring 2024

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class EnvironmentManager : MonoBehaviour
{
    //public string mySceneName; 
    // Start is called before the first frame update

    public void GoToDigitalTwins(){
        SceneManager.LoadScene(2); 
        //This line tells Unity to load a different scene 
        //The 2 is because DTProjV is the second scene added
        // to the Scenes in Build area of the Build Settings 
        
    }
}
