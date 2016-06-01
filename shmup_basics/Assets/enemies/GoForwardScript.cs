using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GoForwardScript : MonoBehaviour {

    /*
	// Use this for initialization
	void Start () {
        // DOMove(Vector2 to, float duration, bool snapping)
        transform.DOMoveY(transform.position.y - 150, 2);
        // Sequence mySequence = DOTween.Sequence();
        // mySequence.Append
	}

	// Update is called once per frame
	void Update () {

	}
    */
     public float CurveSpeed = 5;
     public float MoveSpeed = 1;
     public float curvMag = 1;

     float fTime = 0;
     Vector3 vLastPos = Vector3.zero;
     Vector3 svLastPos = Vector3.zero;

     // Use this for initialization
     void Start ()
     {
         // vLastPos = transform.position;
         svLastPos = transform.position;
     }

     // Update is called once per frame
     void Update ()
     {
         vLastPos = transform.position;

         // fTime += Time.deltaTime * CurveSpeed;

         // Vector3 vSin = new Vector3(Mathf.Sin(fTime), -Mathf.Sin(fTime), 0);
         // Vector3 vLin = new Vector3(MoveSpeed, MoveSpeed, 0);

         // transform.position += (vSin + vLin) * Time.deltaTime;


        transform.position = svLastPos + new Vector3(MoveSpeed * Time.time,
                                                     Mathf.Sin(Time.time * CurveSpeed) * curvMag,
                                                     0.0f);


         Debug.DrawLine(vLastPos, transform.position, Color.green, 100);
     }
}
