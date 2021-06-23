using System.Collections.Generic;
using UnityEngine;

public class LuckyBoxItemGenerator : MonoBehaviour
{
    public Animator luckyBoxAnimator;
    public GameConstants constants;

    [System.Serializable]
    public class LuckyBoxItem
    {
        public GameObject prefab;

        [Range(0.0f, 1.0f)]
        public float probability;
    }

    public List<LuckyBoxItem> items;

    private bool generated = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player") && !generated)
        {
            GenerateLuckyItem();
            generated = true;
            luckyBoxAnimator.SetTrigger("Emitted_trig");
            luckyBoxAnimator.SetBool("Emitted_b", true);
        }
    }

    private void GenerateLuckyItem()
    {
        int choice = Random.Range(0, items.Count);
        LuckyBoxItem selectedItem = items[choice];
        float rand = Random.Range(0.0f, 1.0f);
        if (rand < selectedItem.probability)
        {
            GameObject generatedItem = Instantiate(selectedItem.prefab,
            Vector3.up * constants.emitOffsetY + transform.position,
            selectedItem.prefab.transform.rotation);
            generatedItem.GetComponent<Rigidbody2D>().AddForce(Vector2.up * constants.emitForce, ForceMode2D.Impulse);
            return;
        }
        else
        {
            GenerateLuckyItem();
        }
    }
}
