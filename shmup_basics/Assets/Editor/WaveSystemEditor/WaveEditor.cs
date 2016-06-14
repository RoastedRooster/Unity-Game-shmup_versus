using UnityEngine;
using UnityEditor;
using System.Collections;
using rr.wavesystem;
using System.Collections.Generic;

namespace rr.editor.wavesystem {

    [CustomEditor (typeof(Wave))]
    public class WaveEditor : Editor {
        SerializedProperty duration;

        public Spawn newSpawn = null;
        public float newTime = 0f;

        void OnEnable() {
            duration = serializedObject.FindProperty("duration");
        }

        public override void OnInspectorGUI() {
            var currentWave = (Wave)target;
            serializedObject.Update();

            EditorGUILayout.PropertyField(duration, new GUIContent("Wave Time"));

            DisplaySpawns(currentWave);

            serializedObject.ApplyModifiedProperties();
        }

        protected void DisplaySpawns(Wave currentWave) {
            EditorGUILayout.LabelField("Spawn List");
            EditorGUI.indentLevel += 1;

            var spawnList = currentWave.spawnList;

            KeyValuePair<Spawn, float> currentSpawn;
            for(var i = 0; i < spawnList.Count; i ++) {
                currentSpawn = spawnList[i];

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Spawn " + i, GUILayout.Width(75));
                if (GUILayout.Button("X", GUILayout.Width(25))) {
                    spawnList.RemoveAt(i);
                }
                EditorGUILayout.EndHorizontal();

                EditorGUI.indentLevel += 1;
                EditorGUILayout.ObjectField("Spawn", currentSpawn.Key, typeof(Spawn), false);
                EditorGUILayout.FloatField("Time", currentSpawn.Value);
                EditorGUI.indentLevel -= 1;
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Add Spawn");

            EditorGUI.indentLevel += 1;
            newSpawn = EditorGUILayout.ObjectField("Spawn", newSpawn, typeof(Spawn), false) as Spawn;
            newTime = EditorGUILayout.FloatField("Time", newTime);
            if (GUILayout.Button("Save", GUILayout.Width(50))) {
                spawnList.Add(new KeyValuePair<Spawn, float>(newSpawn, newTime));
                EditorUtility.SetDirty(currentWave);
            }

            EditorGUI.indentLevel -= 1;


            EditorGUI.indentLevel -= 1;
        }
    }

}

