using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootable : MonoBehaviour {
    public GameObject playerProjectile;
    public Texture2D crosshair;
    public GameObject tip;

    private Ray ray;
    private RaycastHit hit;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    private void OnGUI()
    {
        float x = (Screen.width / 2) - (crosshair.width / 2);
        float y = (Screen.height / 2) - (crosshair.height / 2);
        GUI.DrawTexture(new Rect(x, y, crosshair.width, crosshair.height), crosshair);
    }
    // Update is called once per frame
    void Update () {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

        if (Input.GetButtonDown("Fire1"))
        {
            if (Physics.Raycast(ray, out hit))
            {
                GameObject projectile = Instantiate(playerProjectile,tip.transform.position,Quaternion.identity);
              //  projectile.transform.position = transform.position;
                projectile.GetComponent<Projectile>().direction = (hit.point - projectile.transform.position).normalized;
                projectile.GetComponent<Projectile>().hitPoint = hit.point;
            }
        }
    }
}
