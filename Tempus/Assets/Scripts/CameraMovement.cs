using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float sensitivity = 2f;
    public float smooth = 2f;

    private Vector2 mouseLook;
    private Vector2 smoothLook;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mouseDir = new Vector2(Input.GetAxisRaw("Mouse X")* sensitivity * smooth,
            Input.GetAxisRaw("Mouse Y") * sensitivity * smooth);

        smoothLook.x = Mathf.Lerp(smoothLook.x, mouseDir.x, 1f / smooth);
        smoothLook.y = Mathf.Lerp(smoothLook.y, mouseDir.y, 1f / smooth);

        mouseLook += smoothLook;

        this.transform.localRotation = Quaternion.AngleAxis(-Mathf.Clamp(mouseLook.y, -90, 90), Vector3.right);
        this.transform.parent.gameObject.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, this.transform.parent.gameObject.transform.up);
    }
}
