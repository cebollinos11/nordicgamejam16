using UnityEngine;
using System.Collections;

public class cameraHandler : MonoBehaviour {

    Camera cam;
    [SerializeField]
    float shakeAmplitude;
    [SerializeField]
    float shakeDuration;
    Vector3 originalPos;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            ShaderManager.SS();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    private float yVelocity = 0.0F;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
        originalPos = transform.position; 
      

        
	}

  
    



    
    public void ShakeCam() {
        StartCoroutine(ShakeIT());
    }

   
    IEnumerator ShakeIT() {

        float currentShake = shakeDuration;
           

        do
        {
            
            float y = Mathf.Sin(10*Mathf.PI * Time.time) * shakeAmplitude/100;            
            transform.position += new Vector3(0, -y, 0);   
            //cam.orthographicSize -= y;
            currentShake -= Time.deltaTime;
            

            yield return new WaitForEndOfFrame();

        } while (currentShake > 0);

        transform.position = originalPos;
        

        

    }


}
