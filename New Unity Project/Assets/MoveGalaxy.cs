using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGalaxy : MonoBehaviour {
    public float speed;

    private bool isLanding = false;
    private bool isClockWise = true;
    private GameObject landPlanet;
    private Vector3 LastAngle;
    private Vector3 LastDirection;
    private int waitCount = 0;
	// Use this for initialization
	void Start () {
        gravity.LandEventHandler += new gravity.LandController(GetLand);    
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        if (landPlanet == null)
        {
            isLanding = false;
        }
        else if (waitCount < 5) {
            waitCount++;
        }
        else {
            isLanding = true;
        }

        if (this.LastAngle == null) {
            //Debug.Log("initialize LastAngle");
            this.LastAngle = this.transform.position - landPlanet.transform.position;
        }
        Vector3 direction = this.transform.position - landPlanet.transform.position;

        //Debug.Log("Last:"+this.LastAngle);
        //Debug.Log("Now:"+direction);

        float angle = Vector3.Angle(direction, LastAngle);
        //Debug.Log("Angle:"+angle);

        Vector3 VerticalDirection = new Vector3(1.0f, 1.0f, -(direction.x + direction.y) / direction.z).normalized;
        if (this.LastDirection == null)
        {
            this.LastDirection = VerticalDirection;
        }
        //Debug.Log("Speed Direction:"+VerticalDirection);
        if (Vector3.Angle(this.LastDirection, VerticalDirection) > 90) {
            VerticalDirection = -VerticalDirection;
        }
        //Movement
        if (isLanding && Input.GetKey(KeyCode.D))
        {
            Debug.Log("isMoving!");
            isClockWise = true;
            //GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, angle*180/Mathf.PI, 0.0f));
            GetComponent<Rigidbody>().velocity =  speed* VerticalDirection;
            //GetComponent<Rigidbody>().AddForce(new Vector3(GetComponent<Rigidbody>().velocity.x, 0, -speed));
        }
        else if (isLanding && Input.GetKey(KeyCode.A))
        {
            isClockWise = false;
            //GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, angle*180/Mathf.PI, 0.0f));
            GetComponent<Rigidbody>().velocity = -speed* VerticalDirection;
            //GetComponent<Rigidbody>().AddForce(new Vector3(GetComponent<Rigidbody>().velocity.x, 0, speed));
        }

        //Stop
        if (isLanding && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (isLanding) {
            if (isClockWise)
            {
                //Debug.Log("clockWise!");
                GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, angle, 0.0f));
            }
            else
            {
                //Debug.Log("deClockWise!");
                GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, -angle, 0.0f));
            }
        }
        
        
        this.LastAngle = direction;
        this.LastDirection = VerticalDirection;
    }

    void GetLand(GameObject game) {
        landPlanet = game;
    }
}
