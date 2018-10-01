using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {
    GameObject parent;
    private void Start()
    {
        foreach (ParticleSystem part in this.GetComponentsInChildren<ParticleSystem>())
        {
            part.loop = false;
        }
        parent = this.transform.parent.gameObject;
    }
    private void Update()
    {

        foreach (ParticleSystem part in this.GetComponentsInChildren<ParticleSystem>())
        {
            if (!part.IsAlive())
            {              
                Destroy(this.gameObject);
            }

            if (part.name == "Trail")
            {
                if (part.particleCount == part.maxParticles)
                {
                    this.transform.SetParent(null);
                    if (parent != null)
                    {
                        parent.GetComponent<Revertable>().revert();
                    }      
                }
            }
        }
    }


}
