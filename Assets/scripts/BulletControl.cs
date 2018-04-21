using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    Rigidbody rb;
    private float bullet_speed = 1700f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(transform.forward *bullet_speed * Time.deltaTime);
        Destroy(this.gameObject, .50f);

    }
    void OnCollisionEnter(Collision col)
    {
        //Debug.Log(col.gameObject.tag);
        if (col.gameObject.tag == "enemy")
        {
            col.gameObject.tag = "destroyed";
            Destroy(col.gameObject);
            PlayerController.IncScore(1);          
            Destroy(this);
        }
    }
}
