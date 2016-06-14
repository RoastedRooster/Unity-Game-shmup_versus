using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(PowerUpBehavior))]
public class PowerUpBehaviorInspector : Editor {

    public override void OnInspectorGUI() {
        var script = (PowerUpBehavior)target;

        // script.someProperty = EditorGUILayout.IntField("A value", script.someProperty);
        // script.texture = (Texture)EditorGUILayout.ObjectField("Image", script.texture, typeof(Texture), false);
        script.powerUp = (PowerUp)EditorGUILayout.ObjectField("PowerUp", script.powerUp, typeof(PowerUp), false);
    }
}