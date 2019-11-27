﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class Weapon : MonoBehaviour {

    public GameObject projectile;
    public Transform shotPoint;

    public int rotationOffset;


    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);

        if (Input.GetMouseButtonDown(0)) {
            Instantiate(projectile, shotPoint.position, transform.rotation);

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
        }

        

    }

    


}
