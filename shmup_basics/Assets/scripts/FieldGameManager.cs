using UnityEngine;
using System.Collections;

public class FieldGameManager : MonoBehaviour {

	public GameObject playerField;

	private Vector2 startPoint;
	private Vector2 endPoint;

	// Use this for initialization
	void Start () {
		SpriteRenderer fieldSprite = playerField.GetComponent<SpriteRenderer> ();
		startPoint = new Vector2(fieldSprite.bounds.extents.x, 0.0f);
		// endPoint = ;

		/*
		sprite.bounds.extents.x; //Distance to the right side, from your center point
		-sprite.bounds.extents.x //Distance to the left side
		sprite.bounds.extents.y //Distance to the top
		-sprite.bounds.extents.y //Distance to the bottom
		*/
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
