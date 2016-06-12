using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace rr.ui {

    public class UILink : MonoBehaviour {

        public string sceneToLoad;

        public void Activate() {
            SceneManager.LoadScene(sceneToLoad);
        }

    }

}
