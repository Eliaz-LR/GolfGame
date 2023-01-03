using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using Proyecto26;

public class LeaderBoardMenu : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown level;
    private Transform entryTemplate;
    private static string[] levels = {"Level_Grass"};

    private void Awake()
    {
        entryTemplate = transform.Find("LeaderBoardEntryTemplate");
        level.onValueChanged.AddListener(delegate {
            StartCoroutine(GetHighscores());
        });
        GetScores(levels[0]);
    }
    private IEnumerator GetHighscores()
    {
        string level = levels[this.level.value];
        GetScores(level);
        yield return null;
    }

    private void GetScores(string level)
    {
        RestClient.Get("https://golfgame-8ff30-default-rtdb.europe-west1.firebasedatabase.app/score/"+level+".json").Then(json =>
        {
            Debug.Log("Scores retrieved");
            Dictionary<string, int> scoresDict = JsonParser.Parse(json.Text);
            var sortedScores = from entry in scoresDict orderby entry.Value ascending select entry;
            DisplayHighscores(sortedScores);
        }).Catch(err=>{
            Debug.Log("Scores not retrieved : "+err.Message);
        });
    }

    private void DisplayHighscores(IOrderedEnumerable<KeyValuePair<string, int>> highscores)
    {
        foreach (Transform child in transform)
        {
            if (child != entryTemplate)
            {
                Destroy(child.gameObject);
            }
        }
        int rank = 1;
        foreach (KeyValuePair<string, int> highscore in highscores)
        {
            Transform entryTransform = Instantiate(entryTemplate, transform);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
            entryRectTransform.anchoredPosition = new Vector2(0, -50 * rank -70);
            entryTransform.Find("Position").GetComponent<TextMeshProUGUI>().text = rank.ToString();
            entryTransform.Find("Name").GetComponent<TextMeshProUGUI>().text = highscore.Key;
            entryTransform.Find("Score").GetComponent<TextMeshProUGUI>().text = highscore.Value.ToString();
            rank++;
        }
    }
}
