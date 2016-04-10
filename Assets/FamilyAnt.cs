using UnityEngine;
using System.Collections;

public class FamilyAnt : MonoBehaviour {


    public AnimationCurve jumpCurve;

    public float jumpAmplitude;

    public Sprite alt;

    Vector3 origPos;

    float jumpOffset;

	// Use this for initialization
	void Start () {
        origPos = transform.position;

        jumpOffset = Random.Range(0f, 2f);

        if (Random.Range(0, 2) == 0) {

            GetComponent<SpriteRenderer>().sprite = alt;
        
        }

        if (Random.Range(0, 2)==0) {

            Color c =  Color.Lerp(Color.white, new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f)), 0.3f);
            GetComponent<SpriteRenderer>().flipX = true;
            GetComponent<SpriteRenderer>().color = c;
        }
	}
	
	// Update is called once per frame
	void Update () {

        float addy = jumpCurve.Evaluate(Time.time+jumpOffset) * jumpAmplitude;
        transform.position = new Vector3(origPos.x, origPos.y + addy, origPos.z);
        
        
	
	}
}
