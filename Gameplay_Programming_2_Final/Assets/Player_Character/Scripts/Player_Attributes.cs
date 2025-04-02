using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attributes : MonoBehaviour
{
    [SerializeField] public int MaxHP;
    private int health;

    public void Start()
    {
        health = MaxHP;
    }
    public void Update()
    {
        
    }

    public int GetHP()
    {
        return health;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health -= 1;
            if(collision.gameObject.transform.position.x < transform.position.x)
            {
                SoundManager.instance.RequestSound(3);
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(5, 2, 0), ForceMode.Impulse);
            }
            else if (collision.gameObject.transform.position.x > transform.position.x)
            {
                SoundManager.instance.RequestSound(3);
                gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-5, 2, 0), ForceMode.Impulse);
            }
            if (health == 0)
            {
                SoundManager.instance.RequestSound(4);
                UI_Manager.Instance.EndGame("Ran out of Health");
                Destroy(gameObject);
            }
        }
    }

}
