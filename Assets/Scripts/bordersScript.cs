using UnityEngine;

public class bordersScript : MonoBehaviour
{
    public string win, lose;
    public GameObject gameManager,Player1,Player2;
    GameManager gm;

    private void Start()
    {
        gm = gameManager.GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject==Player1)
        {
            lose = Player1.name;
            win = Player2.name;
            gm.Player2Win();
            
        }
        if (collision.gameObject == Player2)
        {
            lose = Player2.name;
            win = Player1.name;
            gm.Player1Win();
        }
    }

}
