
using UnityEngine;
using TMPro;

public class InputFieldGrabber : MonoBehaviour
{
    [Header("The value we got from the input field")]
    [SerializeField] private string inputText;

    [Header("Showing the reaction to the player")]
    [SerializeField] private TMP_Text reactionTextBox;
    private PlayerManager playerMNG;
    private MenuUIHandler menuUI;

    private void Start()
    {
        playerMNG = PlayerManager.Instance;
        menuUI = FindObjectOfType<MenuUIHandler>();
    }

    public void GrabFromInputField(string input)
    {
        inputText = input;
        DisplayReactionToInput();
    }
    private void DisplayReactionToInput()
    {
        reactionTextBox.text = "Welcome, " + inputText + "! Let's see, if you beat the highscore!";
        playerMNG.currentPlayer = inputText;
        menuUI.ReadyToStart();

    }
}
