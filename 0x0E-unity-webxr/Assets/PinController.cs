using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinController : MonoBehaviour
{
    public int Score = 0;
    GameObject[] pins = new GameObject[10];
    Vector3[] pinPos = new Vector3[10];

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 10; i++)
        {
            pins[i] = transform.GetChild(i).gameObject;
            pinPos[i] = pins[i].transform.localPosition;
            Debug.Log(pins[i].transform.eulerAngles);
        }
    }

    public void checkPins()
    {
        int count = 0;
        for(int i = 0; i < 10; i++)
        {
            if(pins[i].activeSelf == false)
            {
                continue;
            }
            var pinRot = pins[i].transform.eulerAngles;
            if(Vector3.Distance(pinRot, Vector3.right * 270) > 45)
            {
                pins[i].SetActive(false);
                count++;
            }
        }
        Score += count;
    }
}
