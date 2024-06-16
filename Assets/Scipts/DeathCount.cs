using UnityEngine;

public class DeathCount : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI deathCountTxt;

    private void Awake() {
        deathCountTxt.text = $"Death Count : {PlayerPrefs.GetInt("deathCount"),0}";
    }
}
