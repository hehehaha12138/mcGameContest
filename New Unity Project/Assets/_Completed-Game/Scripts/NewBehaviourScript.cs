using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary{
	public float xMin,xMax,zMin,zMax;
}

public class NewBehaviourScript : MonoBehaviour {
	public float speed;
	public Boundary boundary;
	public bool ground = true;
	public GameObject camera;
	public int count = 0;
	//Sound Effect(Cube)
	public AudioClip AC;
	private bool isGround = true;
	private int jumpCount = 2;
    public bool isInit = false;
    public delegate void moveEventHandler(Vector3 position);
    public static event moveEventHandler onMove;

    // Use this for initialization
    void Start () {
        CameraSwitch.on3DCamera += new CameraSwitch.CameraChangeEventHandler(on3D);
        CameraSwitch.on2DCamera += new CameraSwitch.CameraChangeEventHandler(on2D);
    }

    // Update is called once per frame
    void Update () {
		if (GetComponent<Rigidbody> ().position.z > 0.91) {
			isGround = true;
			jumpCount = 2;
		}

	}

	void FixedUpdate(){
        //Gravity
        GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 0.0f, 4.0f));
        //Constraints
        /*GetComponent<Rigidbody> ().position = new Vector3 (
			Mathf.Clamp (GetComponent<Rigidbody> ().position.x, boundary.xMin, boundary.xMax),
			0.0f,
			Mathf.Clamp (GetComponent<Rigidbody> ().position.z, boundary.zMin, boundary.zMax)
		);*/

        if (GetComponent<Rigidbody>().position.x < boundary.xMin)
        {
            GetComponent<Rigidbody>().MovePosition(new Vector3(boundary.xMin, GetComponent<Rigidbody>().position.y, GetComponent<Rigidbody>().position.z));
        }
        else if (GetComponent<Rigidbody>().position.x > boundary.xMax)
        {
            GetComponent<Rigidbody>().MovePosition(new Vector3(boundary.xMax, GetComponent<Rigidbody>().position.y, GetComponent<Rigidbody>().position.z));
        }
        else if (GetComponent<Rigidbody>().position.z < boundary.zMin)
        {
            GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x, GetComponent<Rigidbody>().position.y, boundary.zMin));
        }
        else if (GetComponent<Rigidbody>().position.z > boundary.zMax)
        {
            GetComponent<Rigidbody>().MovePosition(new Vector3(GetComponent<Rigidbody>().position.x, GetComponent<Rigidbody>().position.y, boundary.zMax));
        }

		//Judge current camera
		if(!isInit && camera.GetComponent<Camera> ().enabled){
			float moveHorizonal = Input.GetAxis ("Horizontal");
			float moveVertical  = Input.GetAxis ("Vertical");


            /*//oldMovement
            Vector3 movement;

			if (GetComponent<Rigidbody> ().position.z < 1) {
				movement = new Vector3 (-moveHorizonal, 0.0f, 1);
			} else {
				movement = new Vector3 (-moveHorizonal, 0.0f, 0);
			}
			GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);*/

            

            //Movement
            if (Input.GetKeyDown(KeyCode.D))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(-speed, 0, GetComponent<Rigidbody>().velocity.z);
            }
            else if (Input.GetKeyDown(KeyCode.A)) {
                GetComponent<Rigidbody>().velocity = new Vector3(speed, 0, GetComponent<Rigidbody>().velocity.z);
            }

            //Stop
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }




			//Jump
			if (Input.GetKeyDown (KeyCode.Space)) {
				if (isGround == true ) {
					isGround = false;
					GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody>().velocity.x, (float)0.0,(float)-3.2);
					jumpCount--;
					//GetComponent<Rigidbody> ().AddForce (new Vector3(0,0,100));
					//ground = false;
				}else if(jumpCount > 0){
					GetComponent<Rigidbody> ().velocity = new Vector3 (GetComponent<Rigidbody>().velocity.x, (float)0.0,(float)-3.2);
					jumpCount--;
				}
			}
		}
        onMove(transform.position);
	}


	private void OnTriggerEnter(Collider other){
		if (count > 0 && other.name != "my_plane_test") {
			if (other.gameObject.name == "jump_collider") {
				isGround = true;
				jumpCount = 2;
				return;
			}
			Debug.Log ("获得一个方块！");
			AudioSource.PlayClipAtPoint (AC, transform.localPosition);
			print (other.name);
			Destroy (other.gameObject);
			Destroy (other);
		}
		count++;
	}

	public void OnCollisionEnter(Collision other){
		if (other.gameObject.name == "Objective_Boundary") {
			isGround = true;
			jumpCount = 2;
		}
	}

    public void on3D() {
        transform.Rotate(0, 0, 90);
    }

    public void on2D()
    {
        transform.Rotate(0, 0, -90);
    }
}
