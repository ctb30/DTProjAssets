using System;
using System.IO; 
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class InputController : MonoBehaviour
{
    public string pythonCode ; 
    public string pythonScriptPath = "D:/DigitalTwinProject_2024Boyd/DTProjExternals/PythonControllers/InputController.py";
    //WARNING: The path is hard coded this will need to be changed 
    public string PoseDataPath = "D:/DigitalTwinProject_2024Boyd/DTProjExternals/TextFiles/InputController_PoseData.txt";
    //WARNING: The path is hard coded this will need to be changed 
    public string AutomationpythonScriptPath = "D:/DigitalTwinProject_2024Boyd/DTProjExternals/PythonControllers/InputController_TaskAutomation.py"; 
     //WARNING: The path is hard coded this will need to be changed 
    public Process process = new Process();
    public Process SecondProcess = new Process();
    public List<List<string>> myTasks = new List<List<string>>();
    public Text UserInstructions;
    
    public void taskCompleteClicker(){
        UserInstructions.text = "Learning Mode Ended";
        string[] DirtyPoseData = File.ReadAllLines(PoseDataPath); //Gets the lines from the PoseData that python generated 
         //Create an empty list to save my numbers
        int PoseNumber=0; 
        myTasks.Add(new List<string>()); //Start off with one list in myTasks, it will be filled with Pose0
        foreach(string line in DirtyPoseData) 
        {
            if (line == "STOP")
                {
                    PoseNumber = PoseNumber + 1; // Prepare to save the next pose 
                    myTasks.Add(new List<string>()); //Add a new PoseList to the myTask List
                }
            else
                {
                    myTasks[PoseNumber].Add(line); //Add the ServoPositions to the Pose List
                }
        }
        File.WriteAllText(PoseDataPath, string.Empty);
   }
    public void RepeatTaskClicked(){
        UserInstructions.text = "Task Automation In Progress";
        string AutomationpythonCode =  @"
import xarm 
arm = xarm.Controller('USB') # Connects the xarm through the USB 
"; 
        string myLines = "";
        foreach (var Pose in myTasks)
        {
           int j = 1; 
           foreach(var ServoPosition in Pose)
           {
            string myServoNumber = j.ToString(); 
            myLines= myLines+"arm.setPosition(" + myServoNumber +","+ ServoPosition + ",2000,True)\n"; 
            j=j+1; 
           }
        }

        string myCommands = AutomationpythonCode + myLines + "\nprint('Thank you, have a wonderful day!')";
        File.WriteAllText(AutomationpythonScriptPath, myCommands); // Write the string with all the python code in the file, File OUTPUT
        //Console.WriteLine("C# program has generated a Python file: " + pythonScriptPath); 
        StartExecuteMyAutomationPythonScript(AutomationpythonScriptPath); 
        EndExecuteMyAutomationPythonScript(AutomationpythonScriptPath);  //Execute the python program
        myCommands="";
        UserInstructions.text = "Thank You! Goodbye!";
    }
    public void savePositionClicked(){
        // NOTE THAT THE DATAFILE IS HARD CODED IN IT WILL NEED TO BE UPDATED 
        UserInstructions.text = "Learning Mode Activated"; //Debug Tool
        string myLines = @"
arm.servoOff([1,2,3,4,5,6])
PoseServoPositions = np.array([str(0)]) 
position1 = str(arm.getPosition(1))
position2 = str(arm.getPosition(2))
position3 = str(arm.getPosition(3))
position4 = str(arm.getPosition(4))
position5 = str(arm.getPosition(5))
position6 = str(arm.getPosition(6))

myLines = position1 + '\n' + position2 +'\n'+ position3 +'\n'+ position4 +'\n'+ position5 +'\n'+ position6 +'\n' + 'STOP' +'\n'
try:
    myDataFile = open('D:/DigitalTwinProject_2024Boyd/DTProjExternals/TextFiles/InputController_PoseData.txt', 'a')
    myDataFile.write(myLines)
except Exception as e:
    print(f'Error: {e}')
finally:
    myDataFile.close()

";
        string myCommands = pythonCode + myLines;
        File.WriteAllText(pythonScriptPath, myCommands); // Write the string with all the python code in the file, File OUTPUT
        //Console.WriteLine("C# program has generated a Python file: " + pythonScriptPath); 
        EndExecuteMyPythonScript(pythonScriptPath);  //Execute the python program
        myCommands="";
    }
    void StartExecuteMyPythonScript(string myScriptPath){
        process.StartInfo.FileName = "python";
        process.StartInfo.Arguments = $"{myScriptPath}";
        process.StartInfo.RedirectStandardOutput = true;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.CreateNoWindow = true;
    }
    void StartExecuteMyAutomationPythonScript(string myScriptPath){
        SecondProcess.StartInfo.FileName = "python";
        SecondProcess.StartInfo.Arguments = $"{myScriptPath}";
        SecondProcess.StartInfo.RedirectStandardOutput = true;
        SecondProcess.StartInfo.UseShellExecute = false;
        SecondProcess.StartInfo.CreateNoWindow = true;
    }
    void EndExecuteMyPythonScript(string myScriptPath){
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        process.WaitForExit();
    }
    void EndExecuteMyAutomationPythonScript(string myScriptPath){
        SecondProcess.Start();
        string output = SecondProcess.StandardOutput.ReadToEnd();
        Console.WriteLine(output);
        SecondProcess.WaitForExit();
    }
    void Start()
    {
        pythonCode =  @"
import xarm 
import numpy as np 
arm = xarm.Controller('USB') # Connects the xarm through the USB 
Task = []
        "; 
        pythonCode = pythonCode + "\narm.servoOff([1,2,3,4,5,6])";
        //UserInstructions.text = "I MADE IT"; //Debug Tool
        StartExecuteMyPythonScript(pythonScriptPath);
    }


    void Update()
    {
        
    }
}
