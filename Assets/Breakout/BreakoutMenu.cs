using UnityEngine;
using UnityEngine.SceneManagement;

namespace Breakout
{
    public class BreakoutMenu : MonoBehaviour
    {
        public void OpenLevel(string scene)
        {
            SceneManager.LoadScene("Breakout"+scene);
        }
    
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
}
