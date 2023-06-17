using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerMove : MonoBehaviour

{
    bool enemySpawn = false;
    bool isDone = false;
    float speed = 20f;
    GameObject[] enemies;

    public GameObject bulletPrefab;



    // Start is called before the first frame update
    void Start()
    {
        
        transform.position = GameObject.FindGameObjectWithTag("manager").transform.position;

        
        enemies = GameObject.FindGameObjectsWithTag("enemy");

        
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
        }

        PlayerPrefs.SetInt("deadEnemy", 0);

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, 0f, Input.GetAxis("Vertical") * Time.deltaTime * speed);

        
        transform.Rotate(0f, Input.GetAxis("Mouse X") * 5f, 0f);

        AnyCollectable();

        
        if (enemySpawn == true && !isDone)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.SetActive(true);
                isDone = true;

            }

            
        }
        
        
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }

    }

    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "collectable")
        {
            Destroy(other.gameObject);
        }
    }

    public void AnyCollectable() {
        
        
        if (GameObject.FindGameObjectsWithTag("collectable").Length == 0)
        {
            enemySpawn = true;
            
           
        }
    
    }

    public void Fire()
    {
        
        Vector3 offset = transform.forward * 2.4f + transform.up * 2f + transform.right * 1.6f;

        
        Vector3 bulletPos = transform.position + offset;

        GameObject bullet = Instantiate(bulletPrefab, bulletPos, Quaternion.identity);

        
        Vector3 playerRotation = transform.rotation.eulerAngles;
        bullet.transform.rotation = Quaternion.Euler(90f, playerRotation.y, playerRotation.z);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            
            rb.AddForce(transform.forward * 2000f);
        }

    }

}
