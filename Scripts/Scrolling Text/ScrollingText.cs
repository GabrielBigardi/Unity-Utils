using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    public Vector3 direction;
    public float moveSpeed;
    public float fadeSpeed;

    TMP_Text textComponent;

    private void Start()
    {
        textComponent = GetComponent<TMP_Text>();
    }

    void Update()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, textComponent.color.a - fadeSpeed * Time.deltaTime);
    }
}
