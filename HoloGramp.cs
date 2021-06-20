using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoloGramp : MonoBehaviour
{
    public GameObject rifer;

    Text ammoText;
    // Start is called before the first frame update
    void Start()
    {
        ammoText = GetComponent<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        ammoText.text = rifer.GetComponent<shoot>().currentAmmo.ToString();
    }
}