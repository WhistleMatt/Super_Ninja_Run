using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp_Script : Attack_Card
{
    public Warp_Script()
    {
        this.Cost = 2;
        this.AttackPower = 3;
        this.ID = 2;
        this.Name = "Teleport";
    }
    public override void Execute()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var camera = GameObject.FindGameObjectWithTag("MainCamera");
        var telpos = camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(telpos, out RaycastHit rayHit))
        {
            var finalPlacement = rayHit.point;
            finalPlacement.y += 1;
            finalPlacement.z = 0;
            player.transform.position = finalPlacement;
            SoundManager.instance.RequestSound(5);
        }
    }
}
