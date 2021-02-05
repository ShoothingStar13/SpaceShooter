using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteriod : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3;
    [SerializeField]
    private GameObject _explosionPrefab; 
    private SpawnManager _spawnManager; 
    // Start is called before the first frame update
    void Start()
    {
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate the asteroid on the z axis by 3m/s
        //transform.Rotate(Vector3.forward *_speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Laser")
        {
            Instantiate(_explosionPrefab,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            if(_spawnManager != null)
            {
                _spawnManager.StartSpawning();
            }
            Destroy(this.gameObject,0.25f);
        }
    }
}
