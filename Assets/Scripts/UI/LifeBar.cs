using System.Collections.Generic;
using UnityEngine;

public class LifeBar : MonoBehaviour
{
    const int MAX_HEALTH = 5;
    private int currentHealth;
    private GameObject[] hearts = new GameObject[MAX_HEALTH];
    [SerializeField] private GameObject heartPrefab;
    [SerializeField] private int heartSpacing = 80;
    [SerializeField] private float animationOffset = 0.1f;

    private void Start()
    {
        currentHealth = MAX_HEALTH;
        for (int i = 0; i < MAX_HEALTH; i++) {
            hearts[i] = Instantiate(heartPrefab, transform);
            hearts[i].GetComponent<Animator>().PlayInFixedTime("IdleHP", 0, i*animationOffset);
            hearts[i].GetComponent<RectTransform>().anchoredPosition = new Vector2(i*heartSpacing, 0);
        }
    }
    public void UpdateHealth(int newHealth)
    {
        if (newHealth < currentHealth) {
            for (int i = newHealth; i < currentHealth; i++) {
                hearts[i].GetComponent<Animator>().Play("FadeHP");
            }
        }
        else if (newHealth > currentHealth) {
            for (int i = 0; i < newHealth; i++) {
                hearts[i].GetComponent<Animator>().PlayInFixedTime("IdleHP", 0, i*animationOffset);
            }
        }
        currentHealth = newHealth;
    }

    //Debug functions
    [ContextMenu("5 health")] void hp5() {UpdateHealth(5);}
    [ContextMenu("4 health")] void hp4() {UpdateHealth(4);}
    [ContextMenu("3 health")] void hp3() {UpdateHealth(3);}
    [ContextMenu("2 health")] void hp2() {UpdateHealth(2);}
    [ContextMenu("1 health")] void hp1() {UpdateHealth(1);}
    [ContextMenu("0 health")] void hp0() {UpdateHealth(0);}
}
