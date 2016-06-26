using System;
using System.Collections.Generic;
using UnityEngine;

namespace rr.agent.pattern {

    public class AgentWithMovePattern : MonoBehaviour {

        public MovePattern pattern;

        private AbstractGoTween _tween;
        private bool _initialized = false;

        public void Update() {
            if (_initialized)
                return;

            if (pattern == null)
                return;

            pattern.ApplyPattern(transform, ref _tween);
            _initialized = true;
        }

        public void Stop() {
            if (_tween != null)
                _tween.destroy();
        }
    }

}
