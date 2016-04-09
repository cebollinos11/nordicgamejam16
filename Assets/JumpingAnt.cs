using UnityEngine;
using System.Collections;

public class JumpingAnt : MonoBehaviour {

    public AnimationCurve jumpCurve;
    bool ready;
    public float jumpTime = 0.2f;
    public float jumpHeight = 2f;
    
    float remainingTime;
    Vector3 origPos;

    public JumpButton jb;

    AudioClip s_jump;

    

	// Use this for initialization
	void Start () {
        ready = true;
        origPos = transform.position;
        s_jump = Resources.Load("Sounds/Jump") as AudioClip;
        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.J)) {
            Jump();
        }
	
	}

    public void Jump() {

        if(ready)
            StartCoroutine(CoJump());
    }

    IEnumerator CoJump() {

        AudioManager.PlayClip(s_jump);

        ready = false;

        remainingTime = jumpTime;

        ShaderManager.LayerMask(GetComponent<SpriteRenderer>(), Color.white);

        float addy =0f;
        do
        {
            addy = jumpCurve.Evaluate((jumpTime-remainingTime)/jumpTime)*jumpHeight;
            transform.position = new Vector3(origPos.x,origPos.y+ addy,origPos.z);
            yield return new WaitForEndOfFrame();
            remainingTime -= Time.deltaTime;
        } while (remainingTime > 0f);

        transform.position = origPos;

        ready = true;

        jb.EnableTheOther();
        
    
    }
}
