using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour {
    public string text;
    public GameObject onHandGun;
    public float pickDistance = 3.0f;

    private bool displayText = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;
        displayText = false;
        if (Physics.Raycast(this.transform.position,this.transform.forward,out hit))
        {
            if (hit.collider.gameObject.tag == "Pickable" && hit.distance < pickDistance)
            {
                displayText = true;
                if (Input.GetButtonDown("Interact"))
                {
                    Destroy(hit.collider.gameObject);
                    onHandGun.SetActive(true);
                }
            }
        }
	}

    private void OnGUI()
    {
        if (displayText)
        {
            GUI.TextArea(new Rect(Screen.width/2 - 100, Screen.height / 2 + 100, 200, 20), text);
        }
    }
}
