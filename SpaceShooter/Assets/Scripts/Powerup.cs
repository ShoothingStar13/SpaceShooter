using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * _speed);

        if(transform.position.y < -6f)
        {
            Destroy(this.gameObject); 
        }
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        //if the other object has a tag of Player
        if(other.tag == "Player")
        {
            //Create an istance of the player script
            Player player = other.GetComponent<Player>();
            //if the player was not found
            if(player != null)
            {
                player.ActivateTripleShot(); 
            }
            //then destroy the powerup
            Destroy(this.gameObject); 
        }
        
    }
}
