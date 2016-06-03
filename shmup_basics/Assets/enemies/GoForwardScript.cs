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

        var path = new GoSpline("route52497");
        var move = Go.to(transform, 4f, new GoTweenConfig()
            .positionPath(path, true));

        var move2 = Go.to(transform, 4f, new GoTweenConfig().positionPath(path, true));

        var chain = new GoTweenChain(new GoTweenCollectionConfig().setIterations(-1));
        chain.append(move);
        chain.append(move2);

        _tween = chain;
        _tween.play();
        /* DOTween tests */
        // DOMove(Vector2 to, float duration, bool snapping)
        //transform.DOMoveY(transform.position.y - 150, 2);
        // Sequence mySequence = DOTween.Sequence();
        // mySequence.Append

        //svLastPos = transform.position;

        /* SIN movement with DOTween */
        // First version : Using DOPath function, may break physic collision
        // DOPath(Vector3[] waypoints, float duration, PathType pathType = Linear, PathMode pathMode = Full3D, int resolution = 10, Color gizmoColor = null)

        // Second version : Using DOMove and give it the waypoints one by one with a corountine
        // DOMove(Vector2 to, float duration, bool snapping)
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
}
