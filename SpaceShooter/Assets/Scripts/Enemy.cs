using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // create a variable for the speed of the enemy
    [SerializeField] 
    private float _speed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //translate the enemy position down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //if the enemy has gone below -6 on the y axis
        if(transform.position.y < -6f)
        {
            //Vector3 teleport = new Vector3(transform.x,7.5f,0)
            //transform.position = teleport
            float randomX = Random.Range(-9.2f,9.2f);
            transform.position = new Vector3(Random.Range(-9.2f,9.2f),7.5f,0);
        }
        //change the position to teleport from the top of the screen from the 7.5f on the y axis 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("Hit: " + other.transform.name);
        if(other.tag == "Laser")
        {
            //Destroy the laser
            Destroy(other.gameObject);
            //Destroy the enemy
            Destroy(this.gameObject);
        }
        if(other.tag == "Player")
        {
            //Damage the player 
            Player player = other.GetComponent<Player>();
            if(player != null)
            {
                player.Damage();
            }
            //Destroy the enemy 
            Destroy(this.gameObject);
        }
    }
}
