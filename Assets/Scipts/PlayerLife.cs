using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private int deathCount;

    [SerializeField] private AudioClip deathSoundEffect;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        deathCount = PlayerPrefs.GetInt("deathCount", 0);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("Traps")) {
            Die();
        }
    }

    private void Die() {
        animator.SetTrigger("death");
        rb.bodyType = RigidbodyType2D.Static;
        AudioManager.Instance.PlaySoundEffect(deathSoundEffect);

        deathCount++;
        PlayerPrefs.SetInt("deathCount", deathCount);
    }

    //Added as event to death animation : 
    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
