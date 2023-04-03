using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Gem");
            FindObjectOfType<AudioManager>().PlaySound("Gem Pick Up");
            PlayerManager.score += 2;
            Destroy(gameObject);
        }
    }
}