using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private int score;
    [SerializeField] private TMPro.TextMeshProUGUI scoreText;

    [SerializeField] private AudioClip collectSoundEffect;

    private void Awake() {
        score = 0;
        scoreText.text = $"Cherries : {score}";
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.CompareTag("Collectable")) {
            Destroy(collision.gameObject);
            scoreText.text = $"Cherries : {++score}";
            AudioManager.Instance.PlaySoundEffect(collectSoundEffect);
        }
    }
}
