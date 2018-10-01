using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revertable : MonoBehaviour {
    public GameObject replacement;
	public void revert()
    {
        GameObject replace = Instantiate(replacement, this.transform.position, this.transform.rotation);
        replace.GetComponent<Rigidbody>().AddForce(Vector3.up*100);
        replace.transform.localScale = transform.localScale;
        Destroy(this.gameObject);
    }
}
