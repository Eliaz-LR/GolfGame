using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown level;
    private Transform entryTemplate;
    private string json;

    private void Awake()
    {
        entryTemplate = transform.Find("LeaderBoardEntryTemplate");
        level.onValueChanged.AddListener(delegate {
            // StartCoroutine(GetHighscores());
        });
        // RetriveFromDatabase("easy");
    }
}
