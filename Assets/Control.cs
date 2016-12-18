using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;
public class Control : MonoBehaviour {

    const double FORWARD_DIVIDER = 7.0;
    const double SIDES_DIVIDER = 5.0;
    private static SerialPort sp;
    private static Thread serialThread;
    // Use this for initialization
    static void Begin() {
        sp = new SerialPort("COM6", 9600);
    }
    static void Connect() {
        System.Console.WriteLine("Connection started");
        while (true)
            try {
                if (!sp.IsOpen)
                    sp.Open();
                sp.ReadTimeout = 1000000;
                sp.Handshake = Handshake.None;
                serialThread = new Thread(recData);
                serialThread.Start();
                System.Console.WriteLine("Port Opened!");
                break;
            } catch (System.SystemException e) {
                if (sp.IsOpen)
                    sp.Close();
                System.Console.WriteLine(e.Message + "PS. Chuj ci w dupe.\n");
                //Thread.Sleep(3000);
            }
    }
    static void recData() {
        if ((sp != null) && (sp.IsOpen)) {
            byte tmp;
            string data = "";
            string avalues = "";
            tmp = (byte) sp.ReadByte();
            while (tmp != 255) {
                data += ((char) tmp);
                tmp = (byte) sp.ReadByte();
                if ((tmp == '>') && (data.Length > 30)) {
                    avalues = data;
                    parseValues(avalues.TrimEnd('\n')); //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    data = "";
                }
            }
        }
    }
    static void parseValues(string str) {
        System.Console.WriteLine("Received: " + str);
        double forward, sides;
        string[] slices = str.Split(',');
        System.Console.WriteLine(slices[2] + " " + slices[4]);
        sides = double.Parse(slices[2].Replace('.', ','));
        forward = double.Parse(slices[4].Replace('.', ','));
        if (forward > FORWARD_DIVIDER) {
            forward = FORWARD_DIVIDER;
        } else if (forward < -FORWARD_DIVIDER) {
            forward = -FORWARD_DIVIDER;
        }
        if (sides > SIDES_DIVIDER) {
            sides = SIDES_DIVIDER;
        } else if (sides < -SIDES_DIVIDER) {
            sides = -SIDES_DIVIDER;
        }
        forward /= FORWARD_DIVIDER;
        sides /= SIDES_DIVIDER;
        System.Console.WriteLine("Forward: " + forward.ToString() + "\n" + "Sides: " + sides.ToString() + "\n");
    }
    static void OnProcessExit(object sender, System.EventArgs e) {
        System.Console.WriteLine("I'm out of here");
        if (sp.IsOpen)
            sp.Close();
        Thread.Sleep(1000);
    }

    // Use this for initialization
    void Start() {
        Begin();
        Connect();
    }

    // Update is called once per frame
    void Update() {

    }
}