using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    // Start is called before the first frame update
   
    [SerializeField] float fltSteerSpeed = 100f;
    [SerializeField] float fltMoveSpeed = 20f;
    [SerializeField] float fltSlowSpeed = 15f;
    [SerializeField] float fltBoostSpeed = 30f;

    void OnCollisionEnter2D(Collision2D other) 
    {
        fltMoveSpeed = fltSlowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost")
        {
            Debug.Log("you are boosting, woooh");
            fltMoveSpeed = fltBoostSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float fltSteerAmount = Input.GetAxis("Horizontal") * fltSteerSpeed * Time.deltaTime;
        float fltMoveAmount = Input.GetAxis("Vertical") * fltMoveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -fltSteerAmount);
        transform.Translate(0, fltMoveAmount, 0);
    }
}
