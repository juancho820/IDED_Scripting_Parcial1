using UnityEngine;

public class Catapult : MonoBehaviour
{
    public float force = 100;

    [SerializeField]
    private GameObject projectileToFire;

    [SerializeField]
    private Transform projectileSpawnTranform;

    GameObject instantiatedobject;

    private void Start()
    {
        projectileToFire = GameObject.FindGameObjectWithTag("Bala");
    }

    public void Fire()
    {
       

        if (Input.GetButtonDown("T"))
        {
            GameObject a = GameObject.Instantiate(projectileToFire, transform.forward, Quaternion.identity) as GameObject;
            a.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
        }
     
    }
}