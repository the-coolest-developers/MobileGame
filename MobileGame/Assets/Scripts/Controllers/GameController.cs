using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class GameController : MonoBehaviour
    {
        float normaltimescale;

        // Start is called before the first frame update
        void Start()
        {
            normaltimescale = Time.timeScale;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }
        public void ResumeGame()
        {
            Time.timeScale = normaltimescale;
        }
    }
}
