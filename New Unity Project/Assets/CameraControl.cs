using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    private GameObject attachment;
    private bool is3D = false;
    private int delayJudge = 0;

	// Use this for initialization
	void Start () {
        gravity.LandEventHandler += new gravity.LandController(OnAttachment);
        gravity.LaunchEventHandler += new gravity.LandController(OnLaunch);
        MoveGalaxy.RotateEventHandler += new MoveGalaxy.TransformController(OnRotate);
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 position;
        if (attachment != null)
        {
            position = this.transform.position - attachment.transform.position;
        }
        else
        {
            position = new Vector3(999.0f, 999.0f, 999.0f);
        }
        float distance = Mathf.Pow(Mathf.Pow(position.x, 2) + Mathf.Pow(position.z, 2), 0.5f);

        //Debug.Log(position);

        if (is3D)
        {
            delayJudge++;
            if (delayJudge > 20) {
                delayJudge = 0;
                if (distance - 2.5 > 0)
                {
                    print(is3D);
                    GameObject parent = this.transform.parent.gameObject;
                    this.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y + 5.96f, parent.transform.position.z);
                    //Debug.Log("huge one!");
                    //this.transform.position -= new Vector3((position.normalized * 5).x,0.0f, (position.normalized * 5).z);
                }
                else
                {
                    //Debug.Log("small one!");
                    this.transform.position = new Vector3(attachment.transform.position.x, this.transform.position.y, attachment.transform.position.z);
                }
            }
           
        }

        
	}

    private void OnAttachment(GameObject attachment) {
        this.attachment = attachment;
    }

    void OnLaunch(GameObject game)
    {
        Debug.Log(game.name + "Launch!");

        if (this.attachment.name == game.name)
        {
            
            this.attachment = null;
        }
    }

    void OnRotate(bool is3D) {
        if (!is3D) {
            delayJudge = 0;
        }
        this.is3D = is3D;
    }
}
