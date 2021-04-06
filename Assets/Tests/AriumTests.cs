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
        
        private Arium _arium;//Arium Instance
  

        [OneTimeSetUp]
        public void SetUp()
        {
            _arium = new Arium();

            SceneManager.LoadScene("MiniGame");//Scene is loaded in game cache memory
        }

        
        [UnityTest]
        public IEnumerator ShouldMoveToPosition()
        {

            Transform playertr = _arium.GetComponent<Transform>("Player");// get tranform component for player object
            Transform walltr=_arium.GetComponent<Transform>("East Wall");//get tranform component for walls object
            PlayerMovement move = new PlayerMovement(Vector2.right,10);//set an action for player to move right direction
            _arium.PerformAction(move, "Player");//Perform an action

            float distancebefore = playertr.position.x - walltr.position.x;
          Console.WriteLine(distancebefore);
          
            yield return new WaitUntil(() => (playertr.position.x - walltr.position.x > distancebefore));
            
            Assert.AreEqual(0.5f,playertr.position.y);
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
           
    }
}
