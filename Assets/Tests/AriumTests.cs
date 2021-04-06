using System;
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
using AriumFramework.Plugins;

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
        public IEnumerator ShouldMoveToPosition()
        {

            Transform playertr = _arium.GetComponent<Transform>("Player");// get tranform component for player object
            Transform walltr=_arium.GetComponent<Transform>("East Wall");//get tranform component for walls object
            PlayerMovement move = new PlayerMovement(Vector2.right,10);//created object for Player 
            _arium.PerformAction(move, "Player");

            float distancebefore = playertr.position.x - walltr.position.x;
          Console.WriteLine(distancebefore);
          
            yield return new WaitUntil(() => (playertr.position.x - walltr.position.x > distancebefore));
            
            Assert.AreEqual(0.5f,playertr.position.y);
        }
        
        
        
        

            [UnityTest]
            public IEnumerator ShouldMoveToPositionForwardSide()
            {
                const float force = 80;

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
            public IEnumerator CollectPickup()
            { const float force=88;
                const string pickup = "Pick Up";
                Transform player = _arium.GetComponent<Transform>("Player");
                Transform pickupTransform =
                    _arium.GetComponent<Transform>(pickup);
                Assert.IsTrue(_arium.FindGameObject(pickup).activeSelf);
                Vector3 position1 = Vector3.Lerp(
                    player.position, pickupTransform.position, 1);
                UnityPushObject.Force=Vector3.forward*force;
                _arium.PerformAction(new UnityPushObject(), "Player");
                player.position=position1;
                yield return new WaitForSeconds(8);
                Assert.IsFalse(_arium.FindGameObject(pickup).activeSelf);
            }
            [UnityTest]
            public IEnumerator ShouldMoveToPositionBackSide()
            {
                const float force = 80;

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
                const float force = 80;

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
                const float force = 100;

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
