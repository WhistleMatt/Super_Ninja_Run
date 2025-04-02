using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchScript : Attack_Card
{
    public PunchScript()
    {
        this.Cost = 0;
        this.AttackPower = 1;
        this.ID = 1;
        this.Name = "Punch";
    }
    public override void Execute()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player != null) 
        {
            var animator = player.GetComponent<Animator>();
            animator.SetTrigger("Attacking");
            var newguy = Resources.Load<GameObject>("Hitboxes/hitbox");
            var transform = player.GetComponent<PartScript>();
            var hitbox = GameObject.Instantiate(newguy, transform.GetRightHand().position + (transform.transform.forward * 2), Quaternion.identity);
        }
        //GameObject.Destroy(player);
    }
}
