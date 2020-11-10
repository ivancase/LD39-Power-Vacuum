using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControls : MonoBehaviour {
    public Collider2D lookZone;
    public GameObject bullet;
    public GameObject barrel;
    public float powerConsumption;

    float bulletAngle;
    bool isFiring;

    void Start() {
        bulletAngle = transform.rotation.eulerAngles.z;
    }

    void FixedUpdate() {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider == lookZone) {

            if (Input.GetAxis("Fire1") != 0 && !isFiring) {
                Instantiate(bullet, barrel.transform.position + barrel.transform.forward, Quaternion.Euler(0, 0, barrel.transform.rotation.eulerAngles.z));
                PowerBar.power -= powerConsumption;
                isFiring = true;
            }
            else if (Input.GetAxis("Fire1") == 0) {
                isFiring = false;
            }

            mousePos -= playerPos;
            bulletAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            bulletAngle -= 90;
        }

        Quaternion desiredRot = Quaternion.Euler(0, 0, bulletAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRot, 3 * Time.deltaTime);
    }
}
