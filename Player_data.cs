using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Player_data
{
    public float playerhelth;
    public int Magammo;

    public Player_data(Player player)
    {
        playerhelth = 100;
        Magammo = player.ammo;
    }
}
