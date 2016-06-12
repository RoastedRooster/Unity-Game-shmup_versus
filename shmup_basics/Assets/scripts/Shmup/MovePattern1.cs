using rr.agent.pattern;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace rr.shmup {

    [CreateAssetMenuAttribute(menuName="Agent System/Pattern/MovePattern1")]
    public class MovePattern1 : MovePattern {

        public override void ApplyPattern(Transform transform, ref AbstractGoTween tween) {

			var path = new GoSpline("little_curve");
            var move = Go.to(transform, 1f, new GoTweenConfig().positionPath(path, true));

            var path2 = new GoSpline("forward_top_bot");
            var move3 = Go.to(transform, 5f, new GoTweenConfig().positionPath(path2, true));

            var chain = new GoTweenChain(new GoTweenCollectionConfig().setIterations(1));

			chain.append(move);
            chain.append(move3);

            tween = chain;
            tween.play();

        }

    }
}
