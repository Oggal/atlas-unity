using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionStopper : MonoBehaviour
{
    [SerializeField] GameObject bladePrefab;
    [SerializeField] Vector3 CenterOffset;
    [SerializeField] float length, width;
    [SerializeField] int xSlices, ySlices;
    Vector3[] bladePos = new Vector3[5];
    GameObject[] blades = new GameObject[5];
    int BladeIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 5; i++)
        {
            blades[i] = Instantiate(bladePrefab);

            int Xslot, Yslot;
            Xslot = Random.Range(0, xSlices);
            Yslot = Random.Range(0, ySlices);
            blades[i].transform.position = transform.position + CenterOffset + new Vector3((width * -0.5f) +(width / xSlices * Xslot), 0, (length * -0.5f) +(length / ySlices * Yslot));
            blades[i].transform.parent = transform;
            blades[i].SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + CenterOffset, new Vector3(width, 0.1f, length));
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Interactable")
        {
            var blade = blades[BladeIndex];
            int Xslot, Yslot;
            Xslot = Random.Range(0, xSlices);
            Yslot = Random.Range(0, ySlices);
            blade.transform.position = transform.position + CenterOffset + new Vector3((width * -0.5f) +(width / xSlices * Xslot), 0, (length * -0.5f) +(length / ySlices * Yslot));
            blade.SetActive(true);
            BladeIndex = (BladeIndex + 1) % 5;

        }
    }
}
