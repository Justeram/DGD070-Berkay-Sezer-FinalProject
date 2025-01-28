using UnityEngine;
using UnityEngine.UI;

public class PadTouchGame : MonoBehaviour
{
    public GameObject[] pads; // D�rt pad objesini tutacak array
    public Color touchedColor = Color.green; // Pad'e dokunuldu�unda renk de�i�imi
    public Text winMessage; // Kazanma mesaj�

    private int padsTouched = 0; // Ka� pad'e dokunuldu�unu sayan de�i�ken
    private bool[] padTouched; // Hangi pad'lerin dokunuldu�unu izleyen array
    private bool gameWon = false; // Oyun kazan�lacak m�?

    void Start()
    {
        padTouched = new bool[pads.Length];
        winMessage.gameObject.SetActive(false); // Kazanma mesaj�n� ba�lang��ta gizle
    }

    // Pad'lere dokunuldu�unda �a�r�lacak metot
    void OnTriggerEnter2D(Collider2D other)
    {
        if (gameWon) return;

        for (int i = 0; i < pads.Length; i++)
        {
            if (other.gameObject == pads[i] && !padTouched[i])
            {
                padTouched[i] = true;
                padsTouched++;
                ChangePadColor(i); // Pad'in rengini de�i�tir
                CheckWinCondition(); // Kazanma durumu kontrol�
                break;
            }
        }
    }

    // Pad'e dokunulunca renk de�i�imi
    void ChangePadColor(int index)
    {
        SpriteRenderer padRenderer = pads[index].GetComponent<SpriteRenderer>();
        if (padRenderer != null)
        {
            padRenderer.color = touchedColor;
        }
    }

    // Kazanma durumu kontrol�
    void CheckWinCondition()
    {
        if (padsTouched == pads.Length)
        {
            gameWon = true;
            DisplayWinMessage(); // Kazanma mesaj�n� g�ster
        }
    }

    // Kazanma mesaj�n� g�ster
    void DisplayWinMessage()
    {
        winMessage.gameObject.SetActive(true);
        winMessage.text = "You Win!";
    }
}
