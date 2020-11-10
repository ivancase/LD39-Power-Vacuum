using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrainPower : MonoBehaviour {
    public Transform target;
    public float drainAmt = 0.1f;

    void OnEnable() {
        PowerBar.powerGain -= drainAmt;
        if (target == null) {
            target = GameObject.Find("BeamTarget").transform;
        }
    }

    void OnDisable() {
        PowerBar.powerGain += drainAmt;
    }

    void FixedUpdate() {
        GetComponent<LineRenderer>().SetPosition(0, transform.position);
        GetComponent<LineRenderer>().SetPosition(1, target.position);
    }
}
