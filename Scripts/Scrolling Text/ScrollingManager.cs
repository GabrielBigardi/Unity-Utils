using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingManager : MonoBehaviour
{
    public static ScrollingManager Instance;

    public Transform scrollingTextPrefab;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void EmitText(Vector2 position, string text, Color color, int fontSize)
    {
        Transform go = Instantiate(scrollingTextPrefab, position, Quaternion.identity);
        go.GetComponent<TMP_Text>().SetText(text);
        go.GetComponent<TMP_Text>().color = color;
        go.GetComponent<TMP_Text>().fontSize = fontSize;

    }
}
