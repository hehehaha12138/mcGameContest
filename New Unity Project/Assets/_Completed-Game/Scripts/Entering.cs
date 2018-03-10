using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entering : MonoBehaviour {
    const float PRECISION = 0.000001f;
    public Material ma;
    public bool isEntering;
    // Use this for initialization
    void Start()
    {
        ma.SetFloat("_Float1", 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (isEntering)
        {
            //Debug.Log(ma.GetFloat("Float1"));
            if (ma.GetFloat("_Float1") < 0.05f) {
                Debug.Log("Entering!");
                isEntering = false;
                return;
            }
            
            ma.SetFloat("_Float1", ma.GetFloat("_Float1") - 0.02f);
        }

    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, ma);
    }
}
