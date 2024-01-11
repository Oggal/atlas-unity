using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PinController : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    public int Score = 0;
    GameObject[] pins = new GameObject[10];
    Vector3[] pinPos = new Vector3[10];

    bool isFirstFrame = true;

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
        UpdateScore();
        if (isFirstFrame)
        {
            isFirstFrame = false;
            return;
        }
        
        ResetPins();
    }

    public void UpdateScore()
    {
        ScoreText.text = Score.ToString();
    }

    public void ResetPins()
    {
        isFirstFrame = true;
        for(int i = 0; i < 10; i++)
        {
            pins[i].SetActive(true);
            pins[i].transform.localPosition = pinPos[i];
            pins[i].transform.eulerAngles = Vector3.right * 270;
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}
