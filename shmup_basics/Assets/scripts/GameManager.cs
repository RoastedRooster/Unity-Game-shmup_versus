using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private float timer = 0.0f;
    private UIManager uiManager;
    private bool gameLaunched = false;

    void Start() {
        Time.timeScale = 0.0f;
        uiManager = GameObject.Find("GameScreenUI").GetComponent<UIManager>();
        timer = Time.realtimeSinceStartup + 3.0f;
    }

    void Update() {
        if(!gameLaunched) {
            if(Time.realtimeSinceStartup >= timer) {
                uiManager.toggleTimer();
                Time.timeScale = 1.0f;
                gameLaunched = true;
            } else {
                uiManager.setTimer((int) timer - (int)Time.realtimeSinceStartup);
            }
        }
    }
}
