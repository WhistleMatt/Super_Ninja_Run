using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackScript : MonoBehaviour
{
    private GameObject player;
    private Transform MapStart;

    private void Start()
    {
        MapStart = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) AttachToPlayer();
        if(player != null)
        {
            var newPos = transform.position;
            newPos.x = player.transform.position.x;
            newPos.y = player.transform.position.y + 2;
            transform.position = newPos;
        }
        
    }

    void AttachToPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void ResetCameraPosition()
    {
        this.transform.position = MapStart.position;
    }
}
