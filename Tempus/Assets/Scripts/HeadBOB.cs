using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBOB : MonoBehaviour {
    private float animeTime = 0.0f;
    public float bobSpeed = 0.18f;
    public float bobEffect = 0.1f;
    public float cameraHeight = 0.72f;

    // Update is called once per frame
    void Update () { 
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
    
        //Start of animation
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0) {
            animeTime = 0.0f;
        }
        //
        else {
            waveslice = Mathf.Sin(animeTime);
            animeTime += bobSpeed;

            if (animeTime > Mathf.PI * 2) {
                animeTime -= (Mathf.PI * 2);
            }
        }

        if (waveslice != 0) {
            float totalAxes = Mathf.Clamp(Mathf.Abs(horizontal) + Mathf.Abs(vertical), 0.0f, 1.0f);
            float translateChange = totalAxes * waveslice * bobEffect;
            this.transform.localPosition = new Vector3 (0, cameraHeight + translateChange, 0);
        }

        else {
            transform.localPosition = new Vector3 (0, cameraHeight, 0);
        }
    }
}
