using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float HP;
    public int Ammo;
    // Start is called before the first frame update
    void Start()
    {
        HP = GlobalControl.Instance.HP;
        Ammo = GlobalControl.Instance.Ammo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SavePlayer()
    {
        GlobalControl.Instance.HP = HP;
        GlobalControl.Instance.Ammo = Ammo;
    }
}
