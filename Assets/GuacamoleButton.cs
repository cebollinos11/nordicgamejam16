using UnityEngine;
using System.Collections;

public class GuacamoleButton : Button {

    public Room roomToFill;

    public bool isLeaking;

    [HideInInspector]ParticleSystem particles;

    AudioClip s_hit;
    AudioClip s_water;

    AudioSource aSource;

    public void StartLeaking() {
        isLeaking = true;
        particles.Play();
        aSource.Play();
        
    }

    public void StopLeaking()
    {
        ShaderManager.LayerMask(GetComponent<SpriteRenderer>(), Color.blue);
        particles.Stop();
        isLeaking = false;
        AudioManager.PlayClip(s_hit);
        aSource.Stop();
        
        roomToFill.Drain();
        
    }

    protected override void Start()
    {
        base.Start();
        particles = GetComponentInChildren<ParticleSystem>();
        s_hit = Resources.Load("Sounds/guacamole") as AudioClip;
        s_water = Resources.Load("Sounds/guacamoleWater") as AudioClip;
        aSource = gameObject.AddComponent<AudioSource>();
        aSource.loop = true;
        aSource.clip = s_water;
        
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
