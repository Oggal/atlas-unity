using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSaw : MonoBehaviour
{
    [SerializeField] GameObject gibs;
    ballReturn ballReturn;

    private void Start()
    {
        if (ballReturn == null)
            ballReturn = FindObjectOfType<ballReturn>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            gibs.SetActive(true);
            other.gameObject.SetActive(false);
            StartCoroutine(ballReturn.ReturnBall(other.gameObject));
            gameObject.SetActive(false);
        }
    }

    public IEnumerator DelayedDeactivate()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
