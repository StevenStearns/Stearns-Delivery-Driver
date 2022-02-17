using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 clrHasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 clrNoPackageColor = new Color32(1, 1, 1, 1);

    SpriteRenderer spriteRenderer;

    bool blHasPackage = false;
    [SerializeField] float fltDestroyDelay = 0.5f;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!");
        
    } //OnCollisionEnter2D



    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !blHasPackage)
        {    
                
            Debug.Log("Package picked up");
            blHasPackage = true;
            spriteRenderer.color = clrHasPackageColor;
            Destroy(other.gameObject, fltDestroyDelay);
        }

        if (other.tag == "Customer" && blHasPackage)
        {
            Debug.Log("Package Delivered");
            blHasPackage = false;
            spriteRenderer.color = clrNoPackageColor;
        }
        // Then print "package picked up" to console


    }
} //collision
