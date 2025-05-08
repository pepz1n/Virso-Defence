using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    private float speed;
    private int health;
    private float range;
    public ZombieTypes type;         // Tipo do zumbi, onde as configurações estão definidas
    public LayerMask plantMask;      // Máscara de camada para detectar plantas
    public Plant targetPlant;        // A planta alvo
    private float eatCooldown;
    private bool canEat = true;
    public int damage;

    private Animator animator;       // Referência para o Animator

    private void Start()
    {
        speed = type.speed;
        health = type.health;
        range = type.range;
        eatCooldown = type.eatCooldown;

        // Configura o sprite do zumbi
        GetComponent<SpriteRenderer>().sprite = type.sprite;

        // Inicializa o Animator, pega o Animator do objeto e configura o Animator Controller
        animator = GetComponent<Animator>(); 

        // Configura o Animator Controller do zumbi
        if (type.animator != null)
        {
            animator.runtimeAnimatorController = type.animator;  // Define o Animator Controller no Animator do zumbi
        }
        else
        {
            Debug.LogWarning("O AnimatorController não foi definido para esse tipo de zumbi!");
        }
    }

    private void Update()
    {
        // Verifica se há uma planta dentro do alcance
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.left, range, plantMask);

        if (hit.collider)
        {
            targetPlant = hit.collider.gameObject.GetComponent<Plant>();
            Eat(); // Ataca a planta
        }
        else
        {
            targetPlant = null; // Nenhuma planta encontrada, zumbi anda
        }

        // Se o zumbi tiver saúde 2, troque a sprite para a morte
        if (health == 2)
        {
            GetComponent<SpriteRenderer>().sprite = type.DeathSprite;
            animator.SetTrigger("Die"); // Ativa animação de morte
        }

        // Aqui você pode alternar as animações, dependendo de se o zumbi está andando ou atacando
        if (targetPlant)
        {
            type.StopWalkAnimation(animator);  // Não está andando, está atacando
            type.PlayAttackAnimation(animator);    // Ativa a animação de ataque
        }
        else
        {
            type.PlayWalkAnimation(animator);   // Está andando
        }
    }

    // Método para atacar a planta
    void Eat()
    {
        if (!canEat || !targetPlant)
            return;

        canEat = false;
        Invoke("ResetEatCooldown", eatCooldown);
        targetPlant.Hit(damage); // Aplica dano à planta
    }

    // Reseta o cooldown para o zumbi poder atacar novamente
    void ResetEatCooldown()
    {
        canEat = true;
    }

    private void FixedUpdate()
    {
        // Se o zumbi não tem planta como alvo, ele se move para a esquerda
        if (!targetPlant)
            transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);  // Andando para a esquerda
    }

    // Método para o zumbi receber dano
    public void Hit(int damage)
    {
        health -= damage;
        if (health <= 0)
            Destroy(gameObject);
    }
}
