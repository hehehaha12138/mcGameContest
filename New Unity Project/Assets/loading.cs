using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loading : MonoBehaviour {
    public Material ma;
    public bool isLoading;
	// Use this for initialization
	void Start () {
        ma.SetFloat("_Float1", 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (isLoading) {
            Debug.Log(ma.GetFloat("Float1"));
            ma.SetFloat("_Float1", ma.GetFloat("_Float1") - 0.02f);
        }
        
	}

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, ma);
    }
}
