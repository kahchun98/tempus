using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunMovement : MonoBehaviour {

    public float moveSize = 1;
    public float speed = 1.5f;
    public float bobSpeed = 0.18f;
    public float bobEffect = 0.1f;

    private float offsetX;
    private float offsetY;
    private float animeTime = 0.0f;
    private Vector3 initialPos;
    private Vector3 offsetPos;

    //Use this for initialization
    private void Start()
    {
        initialPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update () {
        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Start of animation
        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            animeTime = 0.0f;
        }
        //
        else
        {
            waveslice = Mathf.Sin(animeTime);
            animeTime += bobSpeed;

            if (animeTime > Mathf.PI * 2)
            {
                animeTime -= (Mathf.PI * 2);
            }
        }

        if (waveslice != 0)
        {
            float totalAxes = Mathf.Clamp(Mathf.Abs(horizontal) + Mathf.Abs(vertical), 0.0f, 1.0f);
            float translateChange = totalAxes * waveslice * bobEffect;
            this.transform.localPosition += new Vector3(0, translateChange, 0);
        }

        else
        {
            transform.localPosition = initialPos;
        }

        offsetX = Input.GetAxis("Mouse X") * Time.deltaTime * moveSize;
        offsetY = Input.GetAxis("Mouse Y") * Time.deltaTime * moveSize;
        offsetPos = new Vector3(initialPos.x + offsetX, initialPos.y + offsetY, initialPos.z);
        transform.localPosition = Vector3.Lerp(transform.localPosition, offsetPos, speed * Time.deltaTime);

    }
}
