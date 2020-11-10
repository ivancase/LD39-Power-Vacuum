using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScrapShop : MonoBehaviour {
    public static int scrap;
    public static int cost = 5;
    public Text scrapCount;
    public Text nextPurchase;

    void FixedUpdate() {
        scrapCount.text = "Scrap: " + scrap;
        nextPurchase.text = "Next Solar Panel: \n" + cost + " scrap.";
    }

    void OnDestroy() {
        scrap = 0;
        cost = 5;
    }
}
