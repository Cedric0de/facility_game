using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
        if (other.gameObject.CompareTag("wall"))
        {
            Debug.Log("walled");
        }
        if (other.gameObject.name == "Player")
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
