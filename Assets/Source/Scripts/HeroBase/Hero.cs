using UnityEngine;

namespace Source.Scripts.HeroBase
{
    public class Hero : MonoBehaviour
    {
        public void Construct()
        {
        }

        public virtual void OnActive()
        {
            gameObject.SetActive(true);
        }

        public virtual void InActive()
        {
            gameObject.SetActive(false);
        }
    }
}