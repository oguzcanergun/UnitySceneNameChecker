using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace OguzcanErgun
{
    namespace CheckSceneName
    {
        public class CheckSceneScript : MonoBehaviour
        {
            [SerializeField] private string sceneName;

            // Update is called once per frame
            void Update()
            {
                if (Input.GetKey(KeyCode.Space))//this is here to simulate desired event trigger
                {
                    LoadANewScene();
                }
            }

            public void LoadANewScene()
            {
                if (CheckSceneName())
                {
                    SceneManager.LoadScene(sceneName);
                }
                else
                {
                    Debug.Log("Problem with the scene name");
                }
            }

            bool CheckSceneName()
            {
                int sceneCount = SceneManager.sceneCountInBuildSettings;//get number of scenes in build settings.
                if (sceneCount > 0)
                {
                    for (int i = 0; i < sceneCount; i++)
                    {
                        string sceneInBuild = Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));//get name of i indexed scene name in build settings parsed out from its file address.
                        if (string.Compare(sceneName, sceneInBuild) == 0)//compare desired scene name with i indexed scene name in build settings.
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}
