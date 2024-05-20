using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private AudioClip finishSoundEffect;
    private Animator animator;
    private bool levelCompleted;

    private void Awake() {
        animator = GetComponent<Animator>();
        levelCompleted = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Player") && !levelCompleted) {
            AudioManager.Instance.PlaySoundEffect(finishSoundEffect);
            animator.SetTrigger("Finish");
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }
    }

    private void CompleteLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
