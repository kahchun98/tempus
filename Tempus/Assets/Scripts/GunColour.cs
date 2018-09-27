using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunColour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Renderer renderer = GetComponent<Renderer>();
        Material mat = renderer.material;

        float emission = Mathf.PingPong(Time.time, 1.0f);

        Color emissionColour = Color.white * Mathf.LinearToGammaSpace(emission);

        mat.SetColor("_EmissionColor", emissionColour);
	}
}
