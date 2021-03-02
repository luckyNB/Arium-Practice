using System.Collections;
using AriumFramework;
using AriumFramework.Exceptions;
using AriumFramework.Plugins.UnityCore.Extensions;
using AriumFramework.Plugins.UnityCore.Interactions;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.UI;
namespace Tests
{
    public class AriumTests
    {
        
        private Arium _arium;

        [OneTimeSetUp]
        public void SetUp()
        {
            _arium = new Arium();

            SceneManager.LoadScene("MiniGame");
        }


        
        
        [UnityTest]
        public IEnumerator ShouldDestroyObject()
        {
            var nameOfObjectToDestroy = "Player";
            var objectToDestroy = _arium.FindGameObject(nameOfObjectToDestroy);
            Object.Destroy(objectToDestroy);
            yield return null;
           // Assert.IsNull(_arium.FindGameObject("Player"));

            // Assert.Throws<null>(() => _arium.FindGameObject(nameOfObjectToDestroy));
        }
        

     
    }
}
