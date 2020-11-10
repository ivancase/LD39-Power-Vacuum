using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerBar : MonoBehaviour {
    public static float power = 100;
    public static float powerGain = 0.1f;
    public GameObject powerBar;
    public GameObject gameOver;
    public AudioClip defeat;
    public Text text;
    float scale;

    public SpriteRenderer lights;
    public Sprite lightsFull;
    public Sprite lights75;
    public Sprite lights50;
    public Sprite lights25;

    void Start() {
        scale = powerBar.transform.localScale.x;
    }

    void FixedUpdate() {
        power += powerGain;
        power = Mathf.Clamp(power, 0, 100);

        if (powerBar != null) {
            powerBar.transform.localScale = new Vector2((power / 100f) * scale, powerBar.transform.localScale.y);
        }

        if (text != null) {
            text.text = power.ToString("F2") + "% \n" + powerGain.ToString("F2") + " / second";
        }

        if(power <= 0) {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            AudioSource.PlayClipAtPoint(defeat, transform.position);
        }
        else if (power <= 25) {
            lights.sprite = lights25;
        }
        else if (power <= 50) {
            lights.sprite = lights50;
        }
        else if (power <= 75) {
            lights.sprite = lights75;
        }
        else {
            lights.sprite = lightsFull;
        }
    }

    private void OnDestroy() {
        power = 100;
        powerGain = 0.1f;
    }
}
