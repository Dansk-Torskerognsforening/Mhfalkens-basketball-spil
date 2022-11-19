using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Basketball : MonoBehaviour
{
    public float KasteKraft = 0.1f;
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] AudioSource Lyd;
    [SerializeField] AudioClip ScoreLyd;
    [SerializeField] AudioClip KasteLyd;
    [SerializeField] AudioClip RamtNogetLyd;

    private int Score = 0;
    private Rigidbody2D Rb;
    private Vector3 MovementStart;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: " + Score;
        Rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDown()
    {
        if (!enabled) return; // Hvis scriptet er disabled skal movement også
        MovementStart = Input.mousePosition;
    }
    private void OnMouseUp()
    {
        if (!enabled) return; // Hvis scriptet er disabled skal movement også
        var MoveDirection = Input.mousePosition - MovementStart;
        Rb.AddForce(MoveDirection * KasteKraft, ForceMode2D.Impulse);
        Lyd.PlayOneShot(KasteLyd);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Lyd.PlayOneShot(RamtNogetLyd,5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!enabled) return; // Hvis scriptet er disabled skal scoring også
        if (collision.gameObject.tag == "BallHit")
        {
            // Vi vil ikke have at bolden går op igennem kurven derfor fjerner vi y-velocity'en.
            if (Rb.velocity.y > 0)
            {
                Rb.velocity = new Vector2(Rb.velocity.x, 0);
                return;
            }
            Score++;
            ScoreText.text = "Score: " + Score;
            Lyd.PlayOneShot(ScoreLyd);
        }
    }
}
