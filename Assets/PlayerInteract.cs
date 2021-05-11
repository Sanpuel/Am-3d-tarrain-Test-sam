using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public int damage = 1;
    public float shootRange = 15.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("fire2"))
        {
            Interact();
        }
    }

    void Interact()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 3);
        if (hit.transform != null)
        {
            Debug.Log(hit.transform.gameObject.name);
            if (hit.transform.gameObject.GetComponent<InteractableItem>() !=null)
            {
                hit.transform.parent = gameObject.transform;
            }

        }
    }
    void Shoot()
    {
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, shootRange);
        if (hit.transform != null)
        {
            Debug.Log(hit.transform.gameObject.name);
            if(hit.transform !=null)
            {
                Debug.Log(hit.transform.gameObject.name);
                hit.transform.gameObject.GetComponent<EnemyHealth>()ReduceHP(damage);
            }
        }
    }

}
