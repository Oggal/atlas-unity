using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ballReturn : MonoBehaviour
{
    [SerializeField]Transform ReturnPoint;
    public UnityEvent OnBallReturned;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Interactable")
        {
            other.GetComponent<Renderer>().enabled = false;
            other.GetComponent<Rigidbody>().isKinematic = true;
            StartCoroutine(ReturnBall(other.gameObject));
        }
    }

    public IEnumerator ReturnBall(GameObject ball)
    {
            yield return new WaitForSeconds(1f);
            if(ball != null)
            {
                var rb = ball.GetComponent<Rigidbody>();
                ball.transform.position = ReturnPoint.position;
                ball.GetComponent<Renderer>().enabled = true;
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                OnBallReturned.Invoke();
            }
    }


}
