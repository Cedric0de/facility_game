using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float velocity = 5f;
    float based;
    float doubled;
    float halved;
    public Camera Cam;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        based = velocity;
        doubled = velocity*2f;
        halved = velocity*0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        LookAtMouse();
    }
    void Move()
    {
        if (Input.GetAxisRaw("Horizontal")>0.4)
        {
            transform.position += new Vector3(velocity,0,0) * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Horizontal")<-0.4){
            transform.position += new Vector3(-velocity,0,0) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(0,0,0);
        }
        if (Input.GetAxisRaw("Vertical")>0.4){
            transform.position += new Vector3(0,0,velocity) * Time.deltaTime;
        }
        else if (Input.GetAxisRaw("Vertical")<-0.4){
            transform.position += new Vector3(0,0,-velocity) * Time.deltaTime;
        }
        else
        {
            transform.position += new Vector3(0,0,0);
        }
    }
    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0) Die();
    }
    private void Die()
    {
        transform.position = new Vector3(0,1,-21);
        health = 100;
    }
    private void LookAtMouse()
    {
        Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);
        targetPoint.y = 1;
        transform.LookAt(targetPoint);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "bullet(Clone)")
        {
            TakeDamage(20);
        }
    }
}
