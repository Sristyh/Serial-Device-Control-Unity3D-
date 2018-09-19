using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;

public class Sending : MonoBehaviour {

    //public static SerialPort sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
    public static SerialPort sp = new SerialPort("\\\\.\\COM23", 9600);
    //public static Animator redanim;
    public static int message;
    public static double counter = 0;
    //float timePassed = 0.0f;
    // Use this for initialization
    void Start () {
		OpenConnection();
    }

    // Update is called once per frame
    public static int Update() {
        //int rotation = int.Parse(serial.ReadLine()); //used to convert string type serial input to integer
        //timePassed+=Time.deltaTime;
        //if(timePassed>=0.2f){

        message = sp.ReadByte();
        if (message == 1)
        {
            print("Push Button Pressed");
            counter = counter + 1;
            print(counter);
            if ((counter%2) != 0)
            {
                print("odd count");
                return 1;
            }
            else
            {
                print("even count");
                return 2;
            }
            //transform.Rotate(0,10,80);//rotation w.r.t x,y and z axis
        }
        else
        {
            return 0;
        }
        //	timePassed = 0.0f;
        //}
    }

    void OpenConnection() 
    {
       if (sp != null) 
       {
         if (sp.IsOpen) 
         {
          sp.Close();
          print("Closing port, because it was already open!");
         }
         else 
         {
          sp.Open();  // opens the connection
          sp.ReadTimeout = 20;  // sets the timeout value before reporting error
          print("Port Opened!");
		//		message = "Port Opened!";
         }
       }
       else 
       {
         if (sp.IsOpen)
         {
          print("Port is already open");
         }
         else 
         {
          print("Port == null");
         }
       }
    }

    public static void OnApplicationQuit() 
    {
       sp.Close();
    }

    public static void sendYellow(){
    	sp.Write("Y");
    }

    public static void sendGreen(){
    	sp.Write("G");
    	//sp.Write("\n");
    }

    public static void sendRed(){
    	sp.Write("R");
    }

    //public  static void rotatecube()


}
