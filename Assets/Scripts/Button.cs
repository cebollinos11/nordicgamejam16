using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    bool wasPressed;
    Vector3 origScale;

    public void ReceiveInputs(bool pressed) {
        if (pressed && !wasPressed)
        {
            Debug.Log("pressed");
            OnPress();
            wasPressed = true;
            ShaderManager.LayerMaskQuick(GetComponent<SpriteRenderer>(), Color.blue);
            transform.localScale *= 2f;
        }

        if (!pressed) {
            wasPressed = false;
        }
            
    }

	// Use this for initialization
	void Start () {
        origScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {

        if (origScale.x < transform.localScale.x)
        {
            transform.localScale = Vector3.Lerp(origScale, transform.localScale, 0.3f);
        }
	
	}


    public virtual void OnPress() { 
    
    }
}
