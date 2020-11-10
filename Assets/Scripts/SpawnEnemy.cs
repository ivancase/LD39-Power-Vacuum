using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {
    public GameObject enemy;
    GameObject[] spawnerList;
    GameObject spawner;

    void Start() {
        spawnerList = GameObject.FindGameObjectsWithTag("spawner");
        Invoke("Spawn", 5);
        Invoke("InvokeSpawn", 5);
    }

    void Spawn() {
        spawner = spawnerList[Random.Range(0, spawnerList.Length)];
        Instantiate(enemy, spawner.transform.position, spawner.transform.rotation);
    }

    void InvokeSpawn() {
        float delay = (1 - TimerToWin.t) * 10;
        int totalSpawns = (int)(TimerToWin.t * 10);
        delay = Mathf.Clamp(delay, 3, 10);
        totalSpawns = Mathf.Clamp(totalSpawns, 0, 5);

        for (int i = 0; i <= totalSpawns; i++) {
            Invoke("Spawn", delay);
            if(i == 0) {
                Invoke("InvokeSpawn", delay);
            }
        }
    }
}
