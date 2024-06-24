using UnityEngine;

namespace DataEvent.Example
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerLife _life;

        public PlayerLife Life => _life;

        private void Awake()
        {
            _life = GetComponent<PlayerLife>();
        }

        private void Start()
        {
            Life.Init();
        }

        private void OnMouseDown()
        {
            Life.TakeDamage(.1f);
        }
    }
}