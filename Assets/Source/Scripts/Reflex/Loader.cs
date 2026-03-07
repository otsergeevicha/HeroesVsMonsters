using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Scripts.Reflex
{
    public class Loader : MonoBehaviour
    {
        private void Start() => 
            SceneManager.LoadSceneAsync(TypeScene.GameScene.ToString());
    }
}