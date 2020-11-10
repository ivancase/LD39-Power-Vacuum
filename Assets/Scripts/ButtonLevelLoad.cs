using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class ButtonLevelLoad : MonoBehaviour {
    public int level;
    public bool isExit;

    //Rewrite this code.

    void Start() {
        Button btn = GetComponent<Button>();
        if (isExit) {
            btn.onClick.AddListener(ExitGame);
        }
        else {
            btn.onClick.AddListener(LoadLevel);
        }

    }

    void ExitGame() {
        Application.Quit();
    }

    void LoadLevel() {
        Time.timeScale = 1;
        SceneManager.LoadScene(level);
    }
}
