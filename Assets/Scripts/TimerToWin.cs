using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerToWin : MonoBehaviour {
    public GameObject bar;
    public GameObject victory;
    public Transform notch;
    public AudioClip victorySound;
    public int timer;
    public static float t;

    float length;
    Vector3 startPos;

    void Start() {
        length = notch.localPosition.x * -1;
        startPos = notch.localPosition;
    }

    void FixedUpdate() {
        Vector3 pos = notch.localPosition;
        pos.x = Mathf.Lerp(startPos.x, length, t);
        if (t < 1) {
            t += Time.deltaTime / timer;
        }
        else {
            Time.timeScale = 0;
            victory.SetActive(true);
            AudioSource.PlayClipAtPoint(victorySound, transform.position);
        }
        notch.localPosition = pos;
    }

    void OnDestroy() {
        t = 0;
    }
}
