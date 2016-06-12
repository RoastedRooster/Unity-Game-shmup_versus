using UnityEngine;
using System.Collections;

public class FieldGameManager : MonoBehaviour {

	public GameObject playerField;
	public GameObject powerUpPrefab;

	private Vector2 startPoint;
	private Vector2 endPoint;
    private Vector2 randPos;

    // Use this for initialization
    void Start () {
		SpriteRenderer fieldSprite = playerField.GetComponent<SpriteRenderer> ();
		startPoint = new Vector2(fieldSprite.bounds.extents.x, 0.0f);
        float width = fieldSprite.bounds.size.x;
        float height = fieldSprite.bounds.size.y;

		startPoint = new Vector2((playerField.transform.position.x - width/2) + 25,
                                 playerField.transform.position.y + height/2);

		endPoint = new Vector2((playerField.transform.position.x + width / 2) - 25,
                               playerField.transform.position.y + height / 2);
        
        randPos = new Vector2(Random.Range(startPoint.x, endPoint.x),
                                      startPoint.y);
    }

    // Update is called once per frame
    void Update () {

        // Debug random position
        Debug.DrawLine(new Vector2(randPos.x - 5, randPos.y + 5),
                       new Vector2(randPos.x + 5, randPos.y - 5),
                       Color.white);
        Debug.DrawLine(new Vector2(randPos.x + 5, randPos.y + 5),
                       new Vector2(randPos.x - 5, randPos.y - 5),
                       Color.white);

        // Cross for start and end point of each field
        Debug.DrawLine(new Vector2(startPoint.x -5, startPoint.y + 5),
                       new Vector2(startPoint.x + 5, startPoint.y - 5),
                       Color.red);

        Debug.DrawLine(new Vector2(startPoint.x + 5, startPoint.y + 5),
                       new Vector2(startPoint.x - 5, startPoint.y - 5),
                       Color.red);

        Debug.DrawLine(new Vector2(endPoint.x - 5, endPoint.y + 5),
                       new Vector2(endPoint.x + 5, endPoint.y - 5),
                       Color.red);

        Debug.DrawLine(new Vector2(endPoint.x + 5, endPoint.y + 5),
                       new Vector2(endPoint.x - 5, endPoint.y - 5),
                       Color.red);
    }
}
