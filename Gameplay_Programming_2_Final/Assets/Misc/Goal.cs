using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private string NextLevel;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(NextLevel.Length > 0) LevelMgr.instance.LoadLevel(NextLevel);
            else
            {
                UI_Manager.Instance.EndGame("End Reached. Player Wins!");
                MusicManager.instance.ChangeTrack();
                GameObject.Destroy(collision.gameObject);
                var enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (var enemy in enemies)
                {
                    GameObject.Destroy(enemy.gameObject);
                }
            }

        }
    }
}
