using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extinguisher : MonoBehaviour {

    public Renderer rend;

    Color[] baseColor = new Color[] {Color.blue, Color.blue, Color.blue};

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 3; i++)
        {
            baseColor[i] = rend.materials[i].color;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseOver()
    {
        for (int i = 0; i < 3; i++)
        {
            rend.materials[i].color = Color.yellow;
        }
    }
    void OnMouseExit()
    {
        for (int i = 0; i < 3; i++)
        {
            rend.materials[i].color = baseColor[i];
        }
    }

    public void resetPosition()
    {

        transform.rotation = Quaternion.identity;
    }


}
