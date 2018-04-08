using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeController : MonoBehaviour {

    private bool isDown = true;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void FixedUpdate()
    {
        //获得球心
        Vector3 parentPosition = this.transform.parent.position;

        //控制障碍物方块前后移动
       
        Transform cube_4 = this.transform.Find("decorate_cube_4");
        Vector3 cube_4_vector = parentPosition - cube_4.position;
        float model = cube_4.localScale.x * cube_4.GetComponent<MeshFilter>().mesh.bounds.size.x;
        //Debug.Log("model"+model);
        if (cube_4_vector.magnitude < 10 - 1) {
            isDown = false;
        } else if (cube_4_vector.magnitude > 10 + 1) {
            isDown = true;
        }
        if (isDown)
        {
            cube_4.position += 0.02f * cube_4_vector.normalized;
        }
        else if (!isDown) {
            cube_4.position -= 0.02f * cube_4_vector.normalized;
        }
        

    }
}
