using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {
    public Transform target;

    void FixedUpdate() {
        if (target != null) {
            Vector3 selfPos = Camera.main.WorldToScreenPoint(transform.position);
            selfPos -= target.position;

            float angle = Mathf.Atan2(selfPos.y, selfPos.x) * Mathf.Rad2Deg;

            Quaternion desiredRot = Quaternion.Euler(0, 0, angle);
            transform.rotation = desiredRot;
        }
    }
}
