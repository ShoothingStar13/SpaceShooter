using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //this variable contains the speed of the player
    [SerializeField]
    private float _speed = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        //take the current position of the player = position (0,0,0) (x,y,z)
        //Vector3(x,y,z) in our case Vector3(0,0,0)
        transform.position = new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        //accessing the transform component Translate(Vector3(1,0,0))
        //Vector3(1,0,0) 1*fps 0*fps 0*fps
        //Vector3(1,0,0) 1*1sec 0*1sec 0*1sec 1m/s
        //Vector3(1,0,0) 1 * 5 * Time.deltaTime 5m/s
        //Vector3(1,0,0) 1 * speed * Time.deltaTime 3.5m/s
        transform.Translate(Vector3.right * _speed * Time.deltaTime); 
    }
}
