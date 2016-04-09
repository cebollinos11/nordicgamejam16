using UnityEngine;
using System.Collections;

public class GuacamoleButton : Button {

    public Room roomToFill;

    public bool isLeaking;

    [HideInInspector]ParticleSystem particles;


    public void StartLeaking() {
        isLeaking = true;
        particles.Play();
    }

    public void StopLeaking()
    {
        ShaderManager.LayerMask(GetComponent<SpriteRenderer>(), Color.blue);
        particles.Stop();
        isLeaking = false;
        
        roomToFill.Drain();
        
    }

    protected override void Start()
    {
        base.Start();
        particles = GetComponentInChildren<ParticleSystem>();
        
    }

    public override void OnPress()
    {
        base.OnPress();

        if (isLeaking)
        {
            StopLeaking();
        }
        
        
        
    }
   

}
