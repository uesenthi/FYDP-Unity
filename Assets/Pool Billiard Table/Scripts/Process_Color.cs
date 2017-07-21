using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;
using System.IO;

public class Process_Color : MonoBehaviour {
    string[] coord;
    public GameObject cue;
    public GameObject yellow;
    // Use this for initialization
    void Start()
    {
        //This section is for using a jpg file for object creation
        Process process = new Process();
        process.StartInfo.FileName = "Image_Process_colour_jpg.exe";
        process.StartInfo.CreateNoWindow = true;
        process.StartInfo.Arguments = "scatter.jpg";
        process.Start();
        process.WaitForExit();
        string[] circles = File.ReadAllLines("colour_coordinates.txt");

        foreach (string circle in circles)
        {
            coord = circle.Split(',');
            Vector3 ball_transform = new Vector3(Convert.ToSingle(coord[1]), (float)42.5939, Convert.ToSingle(coord[2]));
            Quaternion ball_rotation = new Quaternion(0, 0, 0, 0);
            Instantiate(cue, ball_transform, ball_rotation);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
