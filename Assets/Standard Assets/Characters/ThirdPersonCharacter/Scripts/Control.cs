using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;
using System.Threading;
public class Control : MonoBehaviour {
	public static float mSides, mForward;
	const float FORWARD_DIVIDER = 7.0f;
	const float SIDES_DIVIDER = 5.0f;
	public SerialPort sp;
	public int bytes;
	public Thread serialThread;
	public float x1,y1,z1;
	public bool readyToMove = false;
	public float prevY = 0.0f;

	void Start () {
		sp = new SerialPort("COM4", 9600);
		Debug.Log("Connection establishing...");
		connect ();
	}

	static void parseValues(string str)
	{
		float sides, forward;
		Debug.Log("Received: " + str);
		string[] slices = str.Split(',');
		sides = float.Parse(slices[2].Replace('.', ','));
		forward = float.Parse(slices[4].Replace('.', ','));
		if (forward > FORWARD_DIVIDER)
			forward = FORWARD_DIVIDER;

		else if (forward < -FORWARD_DIVIDER)
			forward = -FORWARD_DIVIDER;

		if (sides > SIDES_DIVIDER)
			sides = SIDES_DIVIDER;

		else if (sides < -SIDES_DIVIDER)
			sides = -SIDES_DIVIDER;

		forward /= FORWARD_DIVIDER;
		sides /= SIDES_DIVIDER;
		mForward = forward;
		mSides = sides;
	}





	void recData() {
		if ((sp != null) && (sp.IsOpen)) {
			byte tmp;
			string data = "";
			string avalues="";
			tmp = (byte)sp.ReadByte();
			while(tmp !=255) {
				data+=((char)tmp);
				tmp = (byte)sp.ReadByte();
				if((tmp=='>') && (data.Length > 30)){
					Debug.Log ("xD");
					avalues = data;
					parseValues(avalues.TrimEnd('\n'));
					data="";
				}
			}
		}
	}


	void connect() {
		Debug.Log ("Connection started");
		try {
			sp.Open();
			sp.ReadTimeout = 400;
			sp.Handshake = Handshake.None;
			serialThread = new Thread(recData);
			serialThread.Start ();
			Debug.Log("Port Opened!");
		}catch (SystemException e)
		{
			Debug.Log ("Error opening = "+e.Message);
		}

	}


	void Update () { 

		//if (Input.GetKeyDown ("x")) {
		//	Debug.Log("Connection establishing...");
		//	connect ();
		//}


	}


}