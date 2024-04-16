//SynchronizeTwins.cs
//Courtney Boyd, Virginia State University 
//Digital Twin Project Last Updated April 16 2024

// This Script ensures the robotic arm and the 
// physical arm both begin in the same 
// position. 

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
    public string pythonScriptPath; 
    public string pythonScriptPathRelative; 
    public Process process = new Process();
    // Start is called before the first frame update
    void Start()
    {
        pythonScriptPathRelative = "../Assets/AssetsV7/Resources/DTProjExternals/PythonControllers/EnableSynchronize.py";
        pythonScriptPath = pythonScriptPath = Path.Combine(Application.dataPath, pythonScriptPathRelative); 
        //Application.dataPath is used to give us the location of the project as a whole. 
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
