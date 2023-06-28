using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public int maxPoints = 2;
    public float speed = 10;
    public Image uiPlayer;

    [Header("Key setup")]
    public KeyCode keyCodeMoveUp = KeyCode.UpArrow;
    public KeyCode keyCodeMoveDown = KeyCode.DownArrow;
    public KeyCode keyCodeReset = KeyCode.R;
    public string playerName;

    public Rigidbody2D myRigidbody2D;

    [Header("Points")]
    public int currentPoints;
    public TextMeshProUGUI uiTextPoints;
    public int wins;

    private void Awake()
    {
        ResetPlayer();
    }

    public void SetName(string s)
    {
        playerName = s;
    }

    public void ResetPlayer()
    {
        currentPoints = 0;
        UpdateUI();
    }

    /*
     * void Update() //FORMA NAO OTIMIZADA
    {
        if (Input.GetKey(keyCodeMoveUp))
            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * speed); //posição atual + deslocamento global
                                                                                                           //transform.Translate(transform.up * speed); //dessa forma a unity nao checa a colisor do objeto
        else if (Input.GetKey(keyCodeMoveDown))
            transform.GetComponent<Rigidbody2D>().MovePosition(transform.position + transform.up * -speed); //posição atual + deslocamento global
            //transform.Translate(transform.up * speed * -1); //dessa forma a unity nao checa a colisor do objeto
    }
    */

    void Update()
    {
        if (Input.GetKey(keyCodeMoveUp))
            myRigidbody2D.MovePosition(transform.position + transform.up * speed); //posição atual + deslocamento global
                                                                                                           //transform.Translate(transform.up * speed); //dessa forma a unity nao checa a colisor do objeto
        else if (Input.GetKey(keyCodeMoveDown))
            myRigidbody2D.MovePosition(transform.position + transform.up * -speed); //posição atual + deslocamento global
                                                                                    //transform.Translate(transform.up * speed * -1); //dessa forma a unity nao checa a colisor do objeto
        else if (Input.GetKey(keyCodeReset))
            ResetPlayer();
    }

    public void AddPoint()
    {
        currentPoints++;
        UpdateUI();
        Debug.Log(currentPoints);
        CheckMaxPoints();
    }

    public void ChangeColor(Color c)
    {
        uiPlayer.color = c;
    }

    private void UpdateUI()
    {
        uiTextPoints.text = currentPoints.ToString();
    }

    private void CheckMaxPoints()
    {
        if(currentPoints >= maxPoints) //Win
        {
            GameManager.Instance.EndGame();
            wins++;
            HiscoreManager.Instance.SaveWinner(this);
        }
    }

}
