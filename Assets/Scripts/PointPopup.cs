using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointPopup : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] private int pointValue;
    [SerializeField] private bool positive;

    [Header("Fade Values")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fadeSpeed;

    public ParticleSystem pointParticles, pointPrefab;



    private Canvas canvas;
    private TextMeshProUGUI textMeshPro;
    void Start()
    {
        canvas = GetComponentInChildren<Canvas>();
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>();
        if (positive)
        {
            textMeshPro.text = "+" + pointValue.ToString();
        }
        else
        {
            textMeshPro.text = "-" + pointValue.ToString();
        }

        StartCoroutine(AnimateCanvas());
        pointParticles = ParticleSystem.Instantiate(pointPrefab, this.transform.position, Quaternion.identity);
        pointParticles.Play();
    }

    IEnumerator AnimateCanvas()
    {
        gameObject.SetActive(true);

        // Move the canvas up slowly for 1 second
        float elapsedTime = 0f;
        Vector3 startPosition = canvas.transform.position;
        Vector3 targetPosition = startPosition + Vector3.up * moveSpeed;

        while (elapsedTime < 1f)
        {
            canvas.transform.position = Vector3.Lerp(startPosition, targetPosition, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Fade out the alpha value
        Color originalColor = textMeshPro.color;

        while (textMeshPro.color.a > 0)
        {
            textMeshPro.color = new Color(originalColor.r, originalColor.g, originalColor.b, textMeshPro.color.a - fadeSpeed * Time.deltaTime);
            yield return null;
        }

        // Set the canvas to inactive after fading out // CHANGE TO DELETE AFTER
        canvas.gameObject.SetActive(false);
    }

}
