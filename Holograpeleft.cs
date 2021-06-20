using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Holograpeleft : MonoBehaviour
{
    public GameObject ammo;

    Text ammoleftText;
    // Start is called before the first frame update
    void Start()
    {
        ammoleftText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoleftText.text = ammo.GetComponent<PlayerCollect>().points.ToString();
    }
}
