using rr.agent.pattern;
using UnityEngine;
using System.Collections;

[CreateAssetMenuAttribute(menuName="Agent System/Pattern/HoundPopCornPattern")]
public class HoundPopCornPattern : MovePattern {

	public override void ApplyPattern(Transform transform, ref AbstractGoTween tween) {

		var path = new GoSpline("top_to_bot_one_third");
		var move = Go.to(transform, 2f, new GoTweenConfig().positionPath(path, true));

		var path2 = new GoSpline("diag_right_to_left_one_square");
		var move2 = Go.to(transform, 2f, new GoTweenConfig().positionPath(path2, true));

		var path3 = new GoSpline("top_to_bot_one_third");
		var move3 = Go.to(transform, 2f, new GoTweenConfig().positionPath(path3, true));
		var move4 = Go.to(transform, 2f, new GoTweenConfig().positionPath(path3, true));

		var chain = new GoTweenChain(new GoTweenCollectionConfig().setIterations(1));

		chain.append(move);
		chain.append(move2);
		chain.append(move3);
		chain.append(move4);

		tween = chain;
		tween.play();

	}
}
