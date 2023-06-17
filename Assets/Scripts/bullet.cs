using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "enemy")
        {

            other.gameObject.GetComponent<enemy>().hp -= 10;

            if (other.gameObject.GetComponent<enemy>().hp <= 0)
            {
                Destroy(other.gameObject);

            }
            Destroy(this.gameObject);

        }
        else
        {
            Destroy(this.gameObject);
        }
    }


}
