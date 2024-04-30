using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private GameObject player;
    public Boundaries boundaries;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");      
    }
    
    void Update()
    {
        if (boundaries.InFrame == true && GameManager.instance.gameOver == false)
        {
            Vector3 newposition = new Vector3(transform.position.x - speed, player.transform.position.y, 0);
            transform.position = Vector3.Lerp(transform.position, newposition, speed * Time.deltaTime);
        }
    }
}
