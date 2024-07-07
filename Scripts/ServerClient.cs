using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServerClient : MonoBehaviour
{
    Thread thread;
    public int connectionPort = 5050;
    TcpListener server;
    TcpClient client;
    bool running;

    private FireballCool FireballCool;



    void Start()
    {
        // Receive on a separate thread so Unity doesn't freeze waiting for data
        FireballCool = GetComponent<FireballCool>();
        ThreadStart ts = new ThreadStart(GetData);
        thread = new Thread(ts);
        thread.Start();

    }

    public void JSent()
    {
        // This is to move around the fact that I'm using a thread
        FireballCool.setFireballTrue();
        
        // reopens the server to allow multiple calls without reloading
        GetData();
    }

    void GetData()
    {
        // Create the server
        server = new TcpListener(IPAddress.Any, connectionPort);
        server.Start();

        // Create a client to get the data stream
        client = server.AcceptTcpClient();

        // Start listening
        running = true;
        while (running)
        {
            Connection();
        }
        server.Stop();
    }

    void Connection()
    {
        // Read data from the network stream
        NetworkStream nwStream = client.GetStream();
        byte[] buffer = new byte[client.ReceiveBufferSize];
        int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

        // Decode the bytes into a string
        string dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        if(dataReceived == "J")
        {
            UnityEngine.Debug.Log("J has been sent");
            
            // Closes the server to avoid opening a server that already exists
            running = false;
            server.Stop();
            
            JSent();
        }
        if(dataReceived == "K")
        {
            UnityEngine.Debug.Log("K has been sent");
            
            running = false;
            server.Stop();
            GetData();
        }
        if(dataReceived == "L")
        {
            UnityEngine.Debug.Log("L has been sent");
            
            running = false;
            server.Stop();
            GetData();
        }
        if(dataReceived == "Q")
        {
            UnityEngine.Debug.Log("User has closed the camera window");
            
            running = false;
            server.Stop();
            GetData();
        }
        else
        {
            UnityEngine.Debug.Log("Unrecognised character received");
            
            running = false;
            server.Stop();
            GetData();
        }

    }


}
