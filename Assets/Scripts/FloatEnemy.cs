using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEnemy : MonoBehaviour {
    public float distMin;
    public float distMax;
    public float speed;

    bool isMoving;

    Vector3 location;
    float distanceVert;
    float distanceHoriz;

    void FixedUpdate() {
        if (!isMoving) {
            distanceVert = Random.Range(distMin, distMax);
            distanceHoriz = Random.Range(distMin, distMax);
            location = transform.position; 

            location.x += distanceVert;
            location.y += distanceHoriz;

            isMoving = true;
        }
        else {
            transform.position = Vector3.Lerp(transform.position, location, speed * Time.deltaTime);
            if (Mathf.Abs(transform.position.x - location.x) <= 0.1f && Mathf.Abs(transform.position.y - location.y) <= 0.1f) {
                isMoving = false;
                Debug.Log("Succ");
            }
        }

    }

    void OnCollisionEnter2D(Collision2D other) {
        location.x -= distanceVert;
        location.y -= distanceHoriz;
    }

    //In case it falls out.

    void OnTriggerExit2D(Collider2D other) {
        Destroy(gameObject);
    }

}
