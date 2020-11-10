using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yeah, probably should have used the animator for this, but it's a pain in the ass and I'm running out of time.

public class BobUpDown : MonoBehaviour {
    float maxHeight;
    float minHeight;
    bool goUp = true;

    public float speed;

    void Start() {
        maxHeight = transform.position.y + 0.15f;
        minHeight = transform.position.y - 0.15f;
    }

    void Update() {

        float currentHeight = transform.position.y;
        float dist = 0.01f * speed;

        if (goUp) {
            currentHeight += dist;

            if (transform.position.y >= maxHeight) {
                goUp = false;
            }

        }

        else {
            currentHeight -= dist;

            if (transform.position.y <= minHeight) {
                goUp = true;
            }
        }

        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

    }
}
