using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirarArma : MonoBehaviour {
    
    GameObject arma;
    GameObject arma2;
    Vector3 armaPosition;
    bool gunIsPicked = true;

    private void Start()
    {
        arma = gameObject.transform.GetChild(0).gameObject;
        arma2 = gameObject.transform.GetChild(1).gameObject;
        arma2.SetActive(false);
    }

    private void SetChild()
    {
        arma = gameObject.transform.GetChild(0).gameObject;
        arma2 = gameObject.transform.GetChild(1).gameObject;
        arma2.SetActive(false);
        arma.SetActive(true);
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            arma.transform.SetAsLastSibling();
            arma2.transform.SetAsFirstSibling();
            SetChild();
        }

        if (Input.GetKeyDown(KeyCode.F) && gunIsPicked)
        {
            arma.transform.parent = null;
            arma.GetComponent<BoxCollider>().enabled = true;
            arma.AddComponent<Rigidbody>();
            arma.GetComponent<Rigidbody>().AddForce(transform.forward * 500f);
            arma.transform.GetChild(0).gameObject.GetComponent<gunShootBullet>().enabled1 = false;
            gunIsPicked = false;
            if (arma2 != null)
            {
                arma2.transform.SetAsFirstSibling();
                arma = arma2;
                arma.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Weapon") {
            gunIsPicked = true;
            Destroy(collision.GetComponent<Rigidbody>());
            collision.GetComponent<BoxCollider>().enabled = false;
            collision.transform.GetChild(0).gameObject.GetComponent<gunShootBullet>().enabled1 = true;
            collision.transform.SetParent(gameObject.transform);
            collision.transform.localPosition = new Vector3(0,0.48f, -0.46f);
            collision.transform.rotation = transform.rotation;
            collision.transform.SetAsLastSibling();
            collision.gameObject.SetActive(false);

        }
    }
}
