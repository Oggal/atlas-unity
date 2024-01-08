using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GutterHelp : MonoBehaviour
{
    public void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Interactable")
        {
            collision.gameObject.GetComponent<Rigidbody>()?.AddForce(Vector3.forward);
        }
        var contact = collision.GetContact(0);
        Debug.DrawRay(contact.point, contact.normal, Color.white);
    }
}
