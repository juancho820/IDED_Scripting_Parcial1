using UnityEngine;

public class RayBeam : MonoBehaviour
{

    [SerializeField]
    private float damage;

    [SerializeField]
    private float rayDistance = 50F;

    public Vector3 targetLocation;
    private Vector3 targetDirection;

    public float DamagePts
    {
        get
        {
            return damage;
        }
    }

    public void Fire()
    {
        
            RaycastHit hit;
            Ray ray = new Ray(transform.position, -transform.right);

            if (Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                Destroy(gameObject);
            }
        
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, targetDirection);
    }
}