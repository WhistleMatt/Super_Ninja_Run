using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxScript : MonoBehaviour
{
    private int timer;
    private AudioSource source;
    private void Start()
    {
        timer = 0;
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        source.Play();
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            var player = GameObject.FindGameObjectWithTag("Player");
            player.GetComponent<Ability_Script>().RecoverMana(1);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        timer++;
        if (timer >= 30)
        {
            Destroy(this.gameObject);
        }
    }
}
