using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] 
    private float _speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //translate laser up
        //speed variable of 8
        transform.Translate(Vector3.up * _speed * Time.deltaTime); 

        if(transform.position.y > 8f)
        {
            //if there is the parent
            if(transform.parent != null)
            {
                //destroy parent
                Destroy(transform.parent.gameObject); 
            }
            Destroy(gameObject);
        }
    }
}
