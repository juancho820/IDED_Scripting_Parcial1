using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Barrier : MonoBehaviour
{
    [SerializeField]
    private DamageType type;

    [SerializeField]
    private float maxHp;

    private float currentHP;

    public float CurrentHP
    {
        get
        {
            return currentHP;
        }

        set
        {
            currentHP = value;
        }
    }

    public void TakeDamage(RayBeam ray)
    {
        currentHP -= ray.DamagePts;
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(Projectile projectile)
    {
        currentHP -= projectile.DamagePts;
        if (currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }

    // Use this for initialization
    private void Start()
    {
        currentHP = maxHp;
    }
}