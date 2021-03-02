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
using System.Collections;
using System.Collections.Generic;
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
            public IEnumerator ShouldMoveToPositionForwardSide()
            {
                const float force = 82;

                Transform playertr = _arium.GetComponent<Transform>("Player");
                // yield return new WaitForSeconds(2);
                UnityPushObject.Force=Vector3.forward*force;
                _arium.PerformAction(new UnityPushObject(), "Player");
                yield return new WaitForSeconds(7);

                float distance = Vector3.Distance(playertr.position, 
                    Vector3.zero);
    
                Assert.IsTrue(distance > 2f);
                Assert.AreEqual( 0.5f,playertr.position.y);

            }  
            [UnityTest]
            public IEnumerator ShouldMoveToPositionBackSide()
            {
                const float force = 82;

                Transform playertr = _arium.GetComponent<Transform>("Player");
                // yield return new WaitForSeconds(2);
                UnityPushObject.Force=Vector3.back*force;
                _arium.PerformAction(new UnityPushObject(), "Player");
                yield return new WaitForSeconds(7);

                float distance = Vector3.Distance(playertr.position, 
                    Vector3.zero);
    
                Assert.IsTrue(distance > 2f);
                Assert.AreEqual( 0.5f,playertr.position.y);

            }   
            [UnityTest]
            public IEnumerator ShouldMoveToPositionleftSide()
            {
                const float force = 82;

                Transform playertr = _arium.GetComponent<Transform>("Player");
                // yield return new WaitForSeconds(2);
                UnityPushObject.Force=Vector3.left*force;
                _arium.PerformAction(new UnityPushObject(), "Player");
                yield return new WaitForSeconds(7);

                float distance = Vector3.Distance(playertr.position, 
                    Vector3.zero);
    
                Assert.IsTrue(distance > 2f);
                Assert.AreEqual( 0.5f,playertr.position.y);

            }   
            [UnityTest]
            public IEnumerator ShouldMoveToPositionRightSide()
            {
                const float force = 82;

                Transform playertr = _arium.GetComponent<Transform>("Player");
                // yield return new WaitForSeconds(2);
                UnityPushObject.Force=Vector3.right*force;
                _arium.PerformAction(new UnityPushObject(), "Player");
                yield return new WaitForSeconds(7);

                float distance = Vector3.Distance(playertr.position, 
                    Vector3.zero);
    
                Assert.IsTrue(distance > 2f);
                Assert.AreEqual( 0.5f,playertr.position.y);

            }   

            

    }
}
