using UnityEngine;
using UnityEditor;
using System.Collections;
using rr.wavesystem;
using System.Collections.Generic;
using rr.agent.pattern;

namespace rr.editor.wavesystem {

    [CustomEditor (typeof(Wave))]
    public class WaveEditor : Editor {
        SerializedProperty duration;

        public GameObject newEnemy = null;
        public Transform newLocation = null;
        public MovePattern newPattern = null;
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

            Spawn currentSpawn;
            for(var i = 0; i < spawnList.Count; i ++) {
                currentSpawn = spawnList[i];

                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.LabelField("Spawn " + i, GUILayout.Width(75));
                if (GUILayout.Button("X", GUILayout.Width(25))) {
                    spawnList.RemoveAt(i);
                    EditorUtility.SetDirty(currentWave);
                    AssetDatabase.SaveAssets();
                }
                EditorGUILayout.EndHorizontal();

                EditorGUI.indentLevel += 1;
                currentSpawn.enemyPrefab = EditorGUILayout.ObjectField("Object to spawn", currentSpawn.enemyPrefab, typeof(GameObject), false) as GameObject;
                currentSpawn.spawnLocation = EditorGUILayout.ObjectField("Where to spawn", currentSpawn.spawnLocation, typeof(GameObject), false) as Transform;
                currentSpawn.movementPattern = EditorGUILayout.ObjectField("Movement pattern to apply", currentSpawn.movementPattern, typeof(MovePattern), false) as MovePattern;
                currentSpawn.timeBeforeNextSpawn = EditorGUILayout.FloatField("Time before next spawn", currentSpawn.timeBeforeNextSpawn);
                EditorGUI.indentLevel -= 1;
            }
            if (GUILayout.Button("Save", GUILayout.Width(50))) {
                AssetDatabase.SaveAssets();
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Add Spawn");

            EditorGUI.indentLevel += 1;
            newEnemy = EditorGUILayout.ObjectField("Object to spawn", newEnemy, typeof(GameObject), false) as GameObject;
            newLocation = EditorGUILayout.ObjectField("Where to spawn", newLocation, typeof(GameObject), false) as Transform;
            newPattern = EditorGUILayout.ObjectField("Movement pattern to apply", newPattern, typeof(MovePattern), false) as MovePattern;
            newTime = EditorGUILayout.FloatField("Time before next spawn", newTime);
            if (GUILayout.Button("Add", GUILayout.Width(50))) {
                var spawn = new Spawn();
                spawn.enemyPrefab = newEnemy;
                spawn.spawnLocation = newLocation;
                spawn.movementPattern = newPattern;
                spawn.timeBeforeNextSpawn = newTime;
                spawnList.Add(spawn);
                EditorUtility.SetDirty(currentWave);
                AssetDatabase.SaveAssets();
            }

            EditorGUI.indentLevel -= 1;


            EditorGUI.indentLevel -= 1;
        }
    }

}

