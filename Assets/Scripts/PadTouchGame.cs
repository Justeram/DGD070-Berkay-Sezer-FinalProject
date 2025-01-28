using UnityEngine;
using UnityEngine.UI;

public class PadTouchGame : MonoBehaviour
{
    public GameObject[] pads; // Dört pad objesini tutacak array
    public Color touchedColor = Color.green; // Pad'e dokunulduðunda renk deðiþimi
    public Text winMessage; // Kazanma mesajý

    private int padsTouched = 0; // Kaç pad'e dokunulduðunu sayan deðiþken
    private bool[] padTouched; // Hangi pad'lerin dokunulduðunu izleyen array
    private bool gameWon = false; // Oyun kazanýlacak mý?

    void Start()
    {
        padTouched = new bool[pads.Length];
        winMessage.gameObject.SetActive(false); // Kazanma mesajýný baþlangýçta gizle
    }

    // Pad'lere dokunulduðunda çaðrýlacak metot
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameWon) return;

        for (int i = 0; i < pads.Length; i++)
        {
            if (other.gameObject == pads[i] && !padTouched[i])
            {
                padTouched[i] = true;
                padsTouched++;
                ChangePadColor(i); // Pad'in rengini deðiþtir
                CheckWinCondition(); // Kazanma durumu kontrolü
                break;
            }
        }
    }

    // Pad'e dokunulunca renk deðiþimi
    void ChangePadColor(int index)
    {
        SpriteRenderer padRenderer = pads[index].GetComponent<SpriteRenderer>();
        if (padRenderer != null)
        {
            padRenderer.color = touchedColor;
        }
    }

    // Kazanma durumu kontrolü
    void CheckWinCondition()
    {
        if (padsTouched == pads.Length)
        {
            gameWon = true;
            DisplayWinMessage(); // Kazanma mesajýný göster
        }
    }

    // Kazanma mesajýný göster
    void DisplayWinMessage()
    {
        winMessage.gameObject.SetActive(true);
        winMessage.text = "You Win!";
    }
}
