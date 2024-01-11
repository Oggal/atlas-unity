using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControll : MonoBehaviour
{
        [SerializeField] float power = 10f;
        [SerializeField] float assist = 2f;        
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
                                rb.AddForce((Vector3.right * Input.GetAxis("Horizontal")  * power * Time.deltaTime) + Vector3.forward * assist );
                        }
                }
                        
        }

}
