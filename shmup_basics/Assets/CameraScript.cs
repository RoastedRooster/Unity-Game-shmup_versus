using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    public float textureSize = 1f;

    void Awake () {
        float unitsPerPixel = 1f / textureSize;
        Camera.main.orthographicSize = (Screen.height / 2f) * unitsPerPixel;
    }
}
