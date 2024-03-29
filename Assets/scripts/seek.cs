﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class seek : MonoBehaviour { 

    public float Mass = 15;
    public float MaxVelocity = 3;
    public float MaxForce = 15;

    private Vector3 velocity;
    public Transform pTarget;

    // Start is called before the first frame update
    void Start()
    {
        velocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if(other.CompareTag("player")){

            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update()
    {

        var desiredVelocity = pTarget.transform.position - transform.position;
        desiredVelocity = desiredVelocity.normalized * MaxVelocity;

        var steering = desiredVelocity - velocity;
        steering = Vector3.ClampMagnitude(steering, MaxForce);
        steering /= Mass;

        velocity = Vector3.ClampMagnitude(velocity + steering, MaxVelocity);
        transform.position += velocity * Time.deltaTime;
        transform.forward = velocity.normalized;

        Debug.DrawRay(transform.position, velocity.normalized * 2, Color.green);
        Debug.DrawRay(transform.position, desiredVelocity.normalized * 2, Color.magenta);




    }

    


}
