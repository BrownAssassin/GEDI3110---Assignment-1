using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject[] shurikens;

    private Animator animator;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
            Attack();
        
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
        cooldownTimer = 0;

        shurikens[FindShuriken()].transform.position = shootingPoint.position;
        shurikens[FindShuriken()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindShuriken()
    {
        for (int i = 0; i < shurikens.Length; i++)
        {
            if (!shurikens[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}
