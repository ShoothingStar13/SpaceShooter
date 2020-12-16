using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //this variable contains the speed of the player
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private GameObject _laser;
    [SerializeField]
    private float _fireRate = 0.5f;
    private float _canFire = -1f;
    [SerializeField]
    private int _lives = 3;

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
        CalculateMovement();

        //Time.time = 0 _canFire = -1 (When the game starts)
        //Time.time = 0.5 _canfire = -1 (Right after shooting laser)
        //Time.time =0.5 _canfire = 0.5()
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
    }



    void CalculateMovement () 
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //accessing the transform component Translate(Vector3(1,0,0))
        //Vector3(1,0,0) 1*fps 0*fps 0*fps
        //Vector3(1,0,0) 1*1sec 0*1sec 0*1sec 1m/s
        //Vector3(1,0,0) 1 * 5 * Time.deltaTime 5m/s
        //Vector3(1,0,0) 1 * speed * Time.deltaTime 3.5m/s
        //Vector3(1,0,0) 1 * horzontalInput(-1-1) * _speed * Time.deltaTime.
        //transform.Translate(Vector3.right * horizontalInput * _speed * Time.deltaTime); 
        //Vector3(0,1,0) 1y * verticalInput(-1 - 1) * _speed * Time.deltaTime
        //transform.Translate(Vector3.up * verticalInput * _speed * Time.deltaTime);
        //Vector3(horizontalInput,verticalInput,0) * _speed * Time.deltaTime;
        //transform.Translate(new Vector3(horizontalInput,verticalInput,0) * _speed * Time.deltaTime);
        Vector3 direction = new Vector3(horizontalInput,verticalInput,0);
        //(checking if horizontal or vertical) * _speed * Time.deltaTime;
        transform.Translate(direction * _speed * Time.deltaTime);

        //if the player's position is greater or equal to 0 
        // if(transform.position.y >= 0)
        // {
        //     //stop the player from going higher in the screen
        //     transform.position = new Vector3(transform.position.x,0,0);
        // }
        // //if the player's y position is smaller or equal to -3.8f
        // else if(transform.position.y <= -3.8f)
        // {
            //stop the player from going lower than -3.8f
        //     transform.position = new Vector3(transform.position.x,-3.8f,0);
        // }
        //Vector3(transform.position.x,Mathf.Clamp(),0)
        transform.position = new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,-3.8f,0),0);

        //check if the player went past 11.3f on the axis
        if(transform.position.x > 11.3f) 
        {
            //teleport the player to -11.3f on the axis
            transform.position = new Vector3(-11.3f,transform.position.y,0);
        }
        //check if the player went past -11.3f on the axis
        else if (transform.position.x < -11.3f) 
        {
            //teleport the player to 11.3f on the axis
            transform.position = new Vector3(11.3f,transform.position.y,0);
        }
    }

    void FireLaser()
    {
        Debug.Log("Space is pressed");
        _canFire = Time.time + _fireRate;
        //create a clone on the player's position using the default rotation
        Instantiate(_laser,transform.position + new Vector3(0,0.8f,0),Quaternion.identity);
    }

    public void Damage()
    {
        //lives = _lives - 1
        //_lives--;
        _lives-= 1;

        if(_lives < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
