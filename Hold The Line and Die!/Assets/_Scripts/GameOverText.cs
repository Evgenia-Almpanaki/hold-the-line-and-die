using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class GameOverText : MonoBehaviour
{
    private static bool hasWon { get; set; }

    /// <summary>
    /// Sets the game result.
    /// </summary>
    /// <param name="hasWon">The result of the game</param>
    public static void setGameResult(bool hasWon)
    {
        GameOverText.hasWon = hasWon;
    }

    private void Awake()
    {
        Text text = this.GetComponent<Text>();
        if (hasWon)
            text.text = "You Win!";
        else
            text.text = "You Lost!";
    }
}
