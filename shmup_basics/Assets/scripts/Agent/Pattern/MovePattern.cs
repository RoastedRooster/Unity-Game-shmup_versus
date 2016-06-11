using System;
using System.Collections.Generic;
using UnityEngine;

namespace rr.agent.pattern {

    public abstract class MovePattern : ScriptableObject {

        public abstract void ApplyPattern(Transform transform, ref AbstractGoTween tween);

    }

}
