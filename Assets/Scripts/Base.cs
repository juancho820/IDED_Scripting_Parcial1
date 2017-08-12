using UnityEngine;

public delegate void OnBaseDestroyed(Base thisBase);

public delegate void OnTurnFinished();

[RequireComponent(typeof(Collider))]
public class Base : MonoBehaviour
{
    public OnBaseDestroyed onBaseDestroyed;
    public OnTurnFinished onTurnFinished;

    [SerializeField]
    private float maxHP = 500F;

    [SerializeField]
    private Catapult catapult;

    [SerializeField]
    private RayBeam rayBeam;

    private float currentHP;

    private bool canAttack;
    private bool defending;

    public void EnableTurn()
    {
        enabled = true;
        canAttack = true;
    }

    public void AttackWithCatapult()
    {
        Debug.Log("Used Attack with catapult");
        catapult.Fire();
    }

    public void AttackWithRay()
    {
        Debug.Log("Used Attack with ray");
        rayBeam.Fire();
    }

    public void Repair()
    {

        Debug.Log("Used repair");
        int a = 0;
        if(a < 2)
        {
            currentHP += 125;
            a += 1;
        }
        else
        {
            Debug.Log("No puede reparar mas");
        }
        
        this.onTurnFinished();
    }

    public void Defend()
    {
        Debug.Log("Used defend");
        defending = true;
        currentHP = rayBeam.DamagePts / 4;
        this.onTurnFinished();

    }

    public void TakeDamage(RayBeam ray)
    {
        currentHP -= ray.DamagePts;
        if(maxHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void TakeDamage(Projectile projectile)
    {
        currentHP -= projectile.DamagePts;
        if (maxHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    private void Start()
    {
        currentHP = maxHP;

        enabled = false;
        canAttack = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (canAttack)
        {
            if (Input.GetKeyDown("A"))
            {
                AttackWithCatapult();
            }
            
            if (Input.GetKeyDown("S"))
            {
                AttackWithRay();
            }
            if (Input.GetKeyDown("D"))
            {
                Defend();
            }
            if (Input.GetKeyDown("W"))
            {
                Repair();
            }
        }
    }
}