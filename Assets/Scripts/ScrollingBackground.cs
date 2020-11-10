using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    public float speed = 0.05f;
    void FixedUpdate () {
        Vector3 pos = transform.position;
        pos.x -= speed;
        if (pos.x <= -19.5) {
            pos.x *= -1;
        }
        transform.position = pos;
	}
}
