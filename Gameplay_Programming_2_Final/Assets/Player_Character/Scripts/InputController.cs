using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InputController : MonoBehaviour
{
    private Animator anim;
    private AudioSource inputSource;
    public bool CanPlay { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        inputSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(UI_Manager.Instance.GameStarted) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                gameObject.GetComponent<Ability_Script>().Cast();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                gameObject.GetComponent<Deck>().SwitchSelectedCard(-1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                gameObject.GetComponent<Deck>().SwitchSelectedCard(1);
            }
            Walk();
            if (Input.GetKeyDown(KeyCode.Space) && !anim.GetBool("Jumped"))
            {
                anim.SetBool("Jumped", true);
                Jump();
            }
        }
    }

    void Walk()
    {
        if ((Input.GetAxis("Horizontal") * Time.deltaTime * 20) != 0)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }
    }

    public void Jump()
    {
        anim.SetTrigger("Jump");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            if (collision.gameObject.transform.position.y < transform.position.y) { 
                anim.SetBool("Falling", false); 
            }
        }
        if(collision.gameObject.tag == "KillPlane")
        {
            SoundManager.instance.RequestSound(6);
            UI_Manager.Instance.EndGame("Fell to Death");
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            anim.SetBool("Falling", false);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            anim.SetBool("Falling", true);
        }
    }
}
