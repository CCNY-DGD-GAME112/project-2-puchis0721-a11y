using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    //My components
    public Rigidbody RB;
    public Animator Anim;
	private Health health;
    //My stats
    public float Speed = 1;
    
    public float SpeedIncreaseRate = 0.5f;
    
    public float MaxSpeed = 10f;
    
    //Who do I walk towards?
    public GameObject Target;

    void Start()
    {
        //At the start of the game I should play my walk animation
        Anim.Play("Walking");
        //I just walk forever, for now.
		health = GetComponent<Health>();
    }

    private void Update()
    {
        if (RB == null) return;

        // Speed increases over time
        Speed = Mathf.Min(Speed + SpeedIncreaseRate * Time.deltaTime, MaxSpeed);

        // Safety check BEFORE using Target
        if (Target == null)
            return;

        try
        {
            transform.LookAt(Target.transform);
        }
        catch (MissingReferenceException)
        {
            Target = null;
            return;
        }
    

        //Rotate to look at the player
        transform.LookAt(Target.transform);
        //Make a temp velocity variable to calculate how I should move
        //By default, I keep my old momentum
        Vector3 vel = RB.linearVelocity;
        //Walk forwards, but don't do it perfectly. Lerp towards my desired speed
        //This makes it so that if I take a knockback it takes a second for me to recover
        vel = Vector3.Lerp(vel,transform.forward * Speed,10*Time.deltaTime);
        //Use my old Y velocity, though. I shouldn't be able to fly
        vel.y = RB.linearVelocity.y;
        //Plug it into my rigidbody
        RB.linearVelocity = vel;
    }
}
