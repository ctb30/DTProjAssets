using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using UnityEngine.UI;

public class SyncronizeTwins : MonoBehaviour
{
    public string pythonCode ; 
    public string pythonScriptPath = "D:/DigitalTwinProject_2024Boyd/DTProjExternals/PythonControllers/EnableSynchronize.py"; 
    //WARNING: The path is hard coded this will need to be changed 
    public Process process = new Process();
    // Start is called before the first frame update
    public void SyncronizeTwinsClicked(){
         pythonCode =  @"
import xarm 
arm = xarm.Controller('USB') # Connects the xarm through the USB
arm.setPosition(6,500,2000,True)
arm.setPosition(5,500,2000,True)
arm.setPosition(4,500,2000,True)
arm.setPosition(3,500,2000,True)
arm.setPosition(2,100,2000,True)
arm.setPosition(1,1000,2000,True)
        ";
        StartExecuteMyPythonScript(pythonScriptPath); 
        File.WriteAllText(pythonScriptPath,pythonCode);
        EndExecuteMyPythonScript(pythonScriptPath);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartExecuteMyPythonScript(string myScriptPath){
        process.StartInfo.FileName = "python";
        process.StartInfo.Arguments = $"{myScriptPath}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
    }
    void EndExecuteMyPythonScript(string myScriptPath){
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        process.WaitForExit();
    }


}
