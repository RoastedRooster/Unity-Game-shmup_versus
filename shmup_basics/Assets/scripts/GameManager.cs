using UnityEngine;
using System.Collections;
using rr.wavesystem;

public class GameManager : MonoBehaviour {

    private float timer = 0.0f;
    private UIManager uiManager;
    private GameObject[] waveManagers;
    private bool gameLaunched = false;

    void Start() {
        Time.timeScale = 0.0f;
        uiManager = GameObject.Find("GameScreenUI").GetComponent<UIManager>();
        waveManagers = GameObject.FindGameObjectsWithTag("waveSystem");
        timer = Time.realtimeSinceStartup + 3.0f;
    }

    void Update() {
        if(!gameLaunched) {
            if(Time.realtimeSinceStartup >= timer) {

                foreach (GameObject waveManager in waveManagers) {
                    waveManager.GetComponent<WaveSystem>().toggle();
                }

                uiManager.toggleTimer();
                Time.timeScale = 1.0f;
                gameLaunched = true;
            } else {
                uiManager.setTimer((int) timer - (int)Time.realtimeSinceStartup);
            }
        }
    }
}
