using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlotController : MonoBehaviour {
    public GameObject myText;
    public string[] plots;
    public int speed;
    public int lineSpeed;

    private StreamReader sR;
    private int counter = 0;

    private string currentPlot = "default:default";
    private int stringCounter = 0;

    private int speedCount = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UnityEngine.UI.Text text = myText.GetComponent<UnityEngine.UI.Text>();
        speedCount++;
        if (speedCount > 1) {
            //Debug.Log(speedCount);
            if (speedCount == speed) {
                speedCount = 0;
            } else if (speedCount == lineSpeed) {
                text.text = "";
                speedCount = 0;
            }
            return;
        }
        
        //Debug.Log("textChange!");
        //获取当前的Text的GameObject
        

        //给CurrentPlot赋值
        if (currentPlot.Equals("default:default")) {
            currentPlot = GetNextString();
        }
        
        //判断当前文本是否完全展示
        if (stringCounter >= currentPlot.Length) {
            speedCount = speed + 1;
            currentPlot = GetNextString();
            stringCounter = 0;
            return;
            //text.text = "";
        }

        text.text += currentPlot[stringCounter];
        stringCounter++;
	}

    string GetNextString() {
        //读出一行文本
        if (sR == null) {
            sR = new StreamReader("Assets/_Completed-Game/Plots/" + plots[counter], true);
            counter++;
        }
        string new_str = sR.ReadLine();
        if (new_str == null)
        {
            if (counter >= plots.Length)
            {
                Debug.Log("Finish Reading!");
                return null;
            }
            else
            {
                sR = new StreamReader("Assets/_Completed-Game/Plots" + plots[counter], true);
                counter++;
                new_str = sR.ReadLine();
            }
        }
        if (new_str[0] == '%') {
            new_str = GetNextString();
        }
        return new_str;
    }
    
}
