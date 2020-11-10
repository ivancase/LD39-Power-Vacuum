using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShopNode : MonoBehaviour {
    public GameObject solarPanel;
    public AudioClip click;

    void Start() {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(buySolarPower);
    }

    void buySolarPower() {
        if (ScrapShop.scrap >= ScrapShop.cost) {
            ScrapShop.scrap -= ScrapShop.cost;
            ScrapShop.cost += 5;
            PowerBar.powerGain += 0.1f;

            GameObject panel = Instantiate(solarPanel, transform.position, transform.rotation);
            panel.transform.SetParent(GameObject.Find("Vessel").transform);

            AudioSource.PlayClipAtPoint(click, transform.position);
            Destroy(gameObject);
        }
        else {
            Debug.Log("Not enough scrap.");
        }
    }
}
