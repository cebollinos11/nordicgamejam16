using UnityEngine;
using System.Collections;

public class ShaderManager : Singleton<ShaderManager> {

    
    public static void   LayerMask(SpriteRenderer sR, Color color){

        Instance.StartCoroutine(MaskIT(sR,color));

    
    }


    static IEnumerator MaskIT(SpriteRenderer sR, Color color)
    {

        float val = 1f;
        sR.material.SetColor("_MaskColor", color);
        sR.material.SetFloat("_MaskAmount", val);

        do
        {
            val -= 0.1f;
            sR.material.SetFloat("_MaskAmount", val);
            yield return new WaitForSeconds(0.02f);

        }
        while (val > 0);

    }
}
