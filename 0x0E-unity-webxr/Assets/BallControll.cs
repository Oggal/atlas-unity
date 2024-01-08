using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
        
        public void OnCollisionStay(Collision col){
                if(col.gameObject.tag == "pins")
                {
                        return;
                }
                if(col.gameObject.tag == "Interactable")
                {
                        var rb = col.gameObject.GetComponent<Rigidbody>();
                        if(rb != null)
                        {
                                rb.AddForce((Vector3.right * Input.GetAxis("Horizontal")  * 2f * Time.deltaTime) + Vector3.forward );
                        }
                }
                        
        }

}
