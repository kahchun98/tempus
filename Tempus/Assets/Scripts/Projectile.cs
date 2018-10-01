using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int speed = 20;
    public Vector3 direction;
    public GameObject postEffect;
    public Vector3 hitPoint;

    private bool untouched = true;


    void Update () {
        if (untouched)
        {
            this.transform.Translate(direction * Time.deltaTime * speed);
        } 
       
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            Destroy(this.gameObject,2);
            untouched = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
            this.transform.parent = collision.transform;
            
            if (collision.gameObject.tag == "Revertable")
            {
                this.transform.position = collision.transform.position;
                this.GetComponent<Rigidbody>().detectCollisions = false;
                GameObject explosion = Instantiate(postEffect, collision.transform.position, collision.transform.rotation);
                explosion.transform.parent = collision.transform;
                Vector3 size = collision.gameObject.GetComponent<MeshRenderer>().bounds.size;
                size /= 2f;
                explosion.GetComponent<CustomSize>().setSize(size.x * size.y * size.z);
            }
        }
    }
}
