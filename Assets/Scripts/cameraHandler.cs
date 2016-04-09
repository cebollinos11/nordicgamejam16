using UnityEngine;
using System.Collections;

public class cameraHandler : MonoBehaviour {

    Camera cam;
    [SerializeField]
    float shakeAmplitude;
    [SerializeField]
    float shakeDuration;



    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            ShakeCam();
        }
    }

    private float yVelocity = 0.0F;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
      

        
	}

    



    
    public void ShakeCam() {
        StartCoroutine(ShakeIT());
    }

   
    IEnumerator ShakeIT() {

        float currentShake = shakeDuration;
        Vector3 originalPos = transform.position;

  

       
        

        do
        {
            
            float y = Mathf.Sin(10*Mathf.PI * Time.time) * shakeAmplitude/100;            
            transform.position += new Vector3(0, -y, 0);   
            //cam.orthographicSize -= y;
            currentShake -= Time.deltaTime;

            Debug.Log(y);

            yield return new WaitForEndOfFrame();

        } while (currentShake > 0);

        transform.position = originalPos;
        

        

    }


}
