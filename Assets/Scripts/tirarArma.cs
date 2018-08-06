using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirarArma : MonoBehaviour {
    
    GameObject arma;
    Vector3 armaPosition;

    private void Start()
    {
        arma = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.F))
        {
            arma.transform.parent = null;
            arma.GetComponent<BoxCollider>().enabled = true;
            arma.AddComponent<Rigidbody>();
            arma.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
            arma.transform.GetChild(0).gameObject.GetComponent<gunShootBullet>().enabled1 = false;
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Weapon") {

            Destroy(collision.GetComponent<Rigidbody>());
            collision.GetComponent<BoxCollider>().enabled = false;
            collision.transform.GetChild(0).gameObject.GetComponent<gunShootBullet>().enabled1 = true;
            collision.transform.SetParent(gameObject.transform);
            collision.transform.localPosition = new Vector3(0,0.48f, -0.46f);
            collision.transform.rotation = transform.rotation;

        }
    }
}
