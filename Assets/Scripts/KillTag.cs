using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTag : MonoBehaviour {
    public string targetTag;
    public AudioClip boom;

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == targetTag) {
            PowerBar.power += 10f;
            ScrapShop.scrap += Random.Range(2, 5);
            AudioSource.PlayClipAtPoint(boom, transform.position);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
