using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadMainScene : MonoBehaviour {
    //public Material ma;
    public GameObject Camera;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Click(){
        Camera.GetComponent<loading>().isLoading = true;
        Invoke("loadScene",2.0f);
        //WaitAndLoad(3.0f);
     
    }

    void loadScene() {
        SceneManager.LoadScene("scene_test_1");
    }

    IEnumerator WaitAndLoad(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        //等待之后执行的动作  
        SceneManager.LoadScene("scene_test_1");
    }
}
