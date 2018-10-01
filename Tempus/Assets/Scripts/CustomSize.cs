using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSize : MonoBehaviour {

    public void setSize(float size)
    {
        foreach (ParticleSystem ps in this.GetComponentsInChildren<ParticleSystem>()) {
            var sz = ps.sizeOverLifetime;
            sz.enabled = true;

            AnimationCurve curve = new AnimationCurve();
            curve.AddKey(0.0f, 0.0f);
            curve.AddKey(0.1f, 1.0f);
            curve.AddKey(0.2f, 1.0f);
            curve.AddKey(0.25f, 0.0f);

            sz.size = new ParticleSystem.MinMaxCurve(size, curve);
        };
        
    }

}
