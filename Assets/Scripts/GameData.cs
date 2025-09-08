using TMPro;
using UnityEngine;

public class GameData : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI applesText;

    [SerializeField] public int applesAmount = 0;

    public void Update ()
    {
        applesText.text = "apples: " + applesAmount.ToString();
    }

    public void SaveGame ()
    {
        PlayerPrefs.SetInt( "applesAmount", applesAmount );
    }


}
