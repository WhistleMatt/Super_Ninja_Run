using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multi_Jump_Script : Traversal_Card
{
    public Multi_Jump_Script() 
    {
        this.Cost = 1;
        this.ID = 100;
        this.Name = "MultiJump";
    }

    public override void Execute()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Animator>().SetTrigger("Card_Jump");
    }
}
