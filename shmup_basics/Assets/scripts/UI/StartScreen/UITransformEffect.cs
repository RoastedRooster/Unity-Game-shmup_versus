using System;
using System.Collections.Generic;
using UnityEngine;

namespace rr.ui {

    public class UITransformEffect : MonoBehaviour {
        public Vector2 from;
        public Vector2 to;
        public float duration;

        void Update() {
            var currentPos = (Vector2)gameObject.transform.position;

            if (currentPos == to) {
                enabled = false;
                return;
            }

            var speed = Vector2.Distance(from, to) / duration;
            var maxDistance = Time.deltaTime * speed;

            gameObject.transform.position = Vector2.MoveTowards(currentPos, to, maxDistance);
        }
    }

}
