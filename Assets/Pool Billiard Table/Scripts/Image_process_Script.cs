using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Diagnostics;
using System.IO;
//using System.IO.Pipes;
using System;

public class Image_process_Script : MonoBehaviour {
    string[] coord;
    public GameObject ball;
	// Use this for initialization
	void Start ()
    {
        //Uncomment this section when using the webcam
        /* 
        Process process = new Process();
        process.StartInfo.FileName = "Image_Process_webcam.exe";
        process.StartInfo.CreateNoWindow = true;
        process.Start();
        process.WaitForExit();
        string[] circles = File.ReadAllLines("circles_coordinates_record.txt");
        */

        //This section is for using a jpg file for object creation
        Process process = new Process();
        process.StartInfo.FileName = "Image_Process_jpg.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.Arguments = "scatter.jpg";
        process.Start();
        process.WaitForExit();
        string[] circles = File.ReadAllLines("circles_coordinates_jpg.txt");

        char[] split = new char[3];
        split[0] = '[';
        split[1] = ']';
        split[2] = ',';
        foreach(string circle in circles)
        {
            coord = circle.Split(split);
            //Uncomment this line when you want to use the actual circle coordinates
            Vector3 ball_transform = new Vector3(Convert.ToSingle(coord[1]), (float) 42.5939, Convert.ToSingle(coord[2]));
            //Vector3 ball_transform = new Vector3((float) -3, (float)42.5939, (float) -0.661);
            Quaternion ball_rotation = new Quaternion(0, 0, 0,0);
            Instantiate(ball, ball_transform, ball_rotation);
        }
    }
	
	// Update is called once per frame
	void Update () {

    }
}
