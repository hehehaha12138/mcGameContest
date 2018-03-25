using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGalaxy : MonoBehaviour {
    public float speed;

    private bool isFirst = true;
    private bool isLanding = false;
    private bool isClockWise = true;
    private GameObject landPlanet;
    private Vector3 LastAngle;
    private Vector3 LastDirection;
    private int waitCount = 0;
    private bool isGround = false;
    private int jumpCount = 2;
    private bool isJump = false;

    // Use this for initialization
    void Start() {
        gravity.LandEventHandler += new gravity.LandController(GetLand);
        gravity.LaunchEventHandler += new gravity.LandController(OnLaunch);
    }

    // Update is called once per frame
    void Update() {

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

        

        // Debug.Log("Landing!!:" + landPlanet.name);
        //Debug.Log("speed:" + GetComponent<Rigidbody>().velocity);
        //Movement
        if (isLanding && Input.GetKey(KeyCode.D))
        {
            Vector3 clockwiseJudge = Vector3.Cross(new Vector3(direction.x, 0.0f, direction.z),
                                               new Vector3(VerticalDirection.x, 0.0f, VerticalDirection.z));


            if (clockwiseJudge.y > 0)
            {
                isClockWise = true;
                Debug.Log("clockwise!");
            }
            else
            {
                isClockWise = false;
                Debug.Log("inverse!");
            }
            
            if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
            {
                isJump = true;
                isGround = false;
                //GetComponent<Rigidbody>().AddForce(30 * direction);
                GetComponent<Rigidbody>().velocity = speed * VerticalDirection + 0.5f * direction;
                jumpCount--;
            }
            else if (isGround)
            {
                //Debug.Log("Normal Move");
                GetComponent<Rigidbody>().velocity = speed * VerticalDirection;
            }


        }
        else if (isLanding && Input.GetKey(KeyCode.A) && jumpCount > 0)
        {
            Vector3 clockwiseJudge = Vector3.Cross(new Vector3(direction.x, 0.0f, direction.z),
                                               new Vector3(-VerticalDirection.x, 0.0f, -VerticalDirection.z));


            if (clockwiseJudge.y > 0)
            {
                isClockWise = true;
                Debug.Log("clockwise!");
            }
            else
            {
                isClockWise = false;
                Debug.Log("inverse!");
            }

           
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isJump = true;
                isGround = false;
                //GetComponent<Rigidbody>().AddForce(30 * direction);
                GetComponent<Rigidbody>().velocity = -speed * VerticalDirection + 0.5f * direction;
                jumpCount--;
            }
            else if (isGround)
            {
                GetComponent<Rigidbody>().velocity = -speed * VerticalDirection;
            }
        }

        //Stop
        if (isLanding && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)))
        {
            isFirst = true;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }

        if (isLanding) {
            if (isClockWise)
            {
                Debug.Log(angle);
                //Debug.Log("clockWise!");
                GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, angle, 0.0f));
                this.transform.Find("Camera").transform.Rotate(new Vector3(0.0f, 0.0f,angle));
            }
            else
            {
                Debug.Log(angle);
                //Debug.Log("deClockWise!");
                GetComponent<Rigidbody>().transform.Rotate(new Vector3(0.0f, -angle, 0.0f));
                this.transform.Find("Camera").transform.Rotate(new Vector3(0.0f, 0.0f, -angle));
            }
        }

        if (!isJump && Input.GetKeyDown(KeyCode.Space)) {
            GetComponent<Rigidbody>().AddForce(150 * direction);
        }

        //Jump
        /*if (isLanding && Input.GetKeyDown(KeyCode.Space)) {
            if (!Input.GetKey(KeyCode.A) || !Input.GetKey(KeyCode.D))
            {

            }
            else
            {
                GetComponent<Rigidbody>().AddForce(25 * direction);
            }
            
        }*/


        this.LastAngle = direction;
        this.LastDirection = VerticalDirection;
    }


    void GetLand(GameObject game) {
        jumpCount = 2;
        isGround = true;
        landPlanet = game;
        isJump = false;
    }

    void OnLaunch(GameObject game)
    {
        if (this.landPlanet == game) {
            this.landPlanet = null;
        }
    }
}
