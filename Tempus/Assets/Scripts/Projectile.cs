﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public int speed = 20;
    public Vector3 direction;

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
        }
    }
}
