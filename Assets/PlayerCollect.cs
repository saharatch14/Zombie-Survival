using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollect : MonoBehaviour
{
    public int points;
    public Player_Propoty player;
    // Start is called before the first frame update
    void Start()
    {
        points = GlobalControl.Instance.Ammo;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnGUI()
    {
        //GUI.Label(new Rect(10, 10, 100, 20),"Ammo "+ " " + " / " + points);

    }
}
