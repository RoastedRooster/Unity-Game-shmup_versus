using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GoForwardScript : MonoBehaviour {
    
     public float CurveSpeed = 5;
     public float MoveSpeed = 1;
     public float curvMag = 1;


    protected AbstractGoTween _tween;

    float fTime = 0;
     Vector3 vLastPos = Vector3.zero;
     Vector3 svLastPos = Vector3.zero;

     // Use this for initialization
     void Start ()
     {

        var path = new GoSpline("little_curve");
        var move = Go.to(transform, 1f, new GoTweenConfig()
            .positionPath(path, true));

        var move2 = Go.to(transform, 1f, new GoTweenConfig().positionPath(path, true));

        var path2 = new GoSpline("forward_top_bot");
        var move3 = Go.to(transform, 5f, new GoTweenConfig().positionPath(path2, true));

        var chain = new GoTweenChain(new GoTweenCollectionConfig().setIterations(1));

        chain.append(move);
        chain.append(move2);
        chain.append(move3);

        _tween = chain;
        _tween.play();
    }

     // Update is called once per frame
     void Update ()
     {

        //vLastPos = transform.position;

        ///* SIN movement working */
        //transform.position = svLastPos + new Vector3(MoveSpeed * Time.time,
        //                                             (Mathf.Sin(Time.time * CurveSpeed) * curvMag) - ((MoveSpeed * Time.time) / 2),
        //                                             0.0f);

        //Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
     }

    public void OnDestroy() {
        _tween.destroy();
    }
}
