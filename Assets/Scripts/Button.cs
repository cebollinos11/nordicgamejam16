using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    bool wasPressed;
    Vector3 origScale;

    public virtual void ReceiveInputs(bool pressed) {
        if (pressed && !wasPressed)
        {
            OnPress();
            wasPressed = true;
            Color col = new Color32(199, 163, 127, 66);
            ShaderManager.LayerMaskQuick(GetComponent<SpriteRenderer>(), col);
            transform.localScale *= 4f;
        }

        if (!pressed) {
            wasPressed = false;
        }
            
    }

    public virtual void ReceiveInputs(float jumpRight,float jumpLeft) { 
    
    }

	// Use this for initialization
	protected virtual void Start () {
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
