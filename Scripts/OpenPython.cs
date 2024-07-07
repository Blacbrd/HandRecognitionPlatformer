using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Drawing;
using System.Data;
using System.ComponentModel;
using System;
using System.IO;
using UnityEngine;


public class OpenPython : MonoBehaviour
{
    private bool programOpen = false;

    private PlayerController PlayerController;


    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && !programOpen && PlayerController.canFireball())
        {   
            // Opens the python server using the command line
            programOpen = true;
            ProcessStartInfo ps = new ProcessStartInfo();
            ps.FileName = "cmd.exe";
            ps.WindowStyle = ProcessWindowStyle.Hidden;
            
            ps.Arguments = @"/k python D:\HandRecognition\PythonServer.py";

            Process.Start(ps);
        }
    // Sets program open to false
        if (Input.GetKeyDown(KeyCode.F) && programOpen == true)
        {
            programOpen = false;
        }
    }
}
