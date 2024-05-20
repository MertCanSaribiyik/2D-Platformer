using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] private AudioClip deathSoundEffect;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); 
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
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
