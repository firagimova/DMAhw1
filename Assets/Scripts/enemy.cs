using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hp = 100;
    float speed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime);
        

    }

    
    


}
