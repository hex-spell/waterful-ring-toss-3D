using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Vector3 Vec;
    // Start is called before the first frame update  
    void Start()
    {

    }

    public float radius = 100;
    public float power = 300;
    // Update is called once per frame  
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 explosionPos = hit.point;
                Debug.Log(explosionPos);

                Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

                Collider[] validColliders = Array.FindAll(colliders, col => col.name.Contains("Floater"));


                foreach (Collider onhit in validColliders)
                {
                    Debug.Log(onhit.name);
                    Rigidbody rb = onhit.GetComponent<Rigidbody>();
                    if (rb != null)
                        rb.AddExplosionForce(power, explosionPos, radius, 3.0F, ForceMode.Impulse);
                }
            }
        }
    }
}