using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class NewTestScript
    {
        [UnityTest]
        public IEnumerator ClickButton()
        {
            var gameObject = new GameObject();
            var colorScript = gameObject.AddComponent<ButtonColorScript>();

            colorScript.greenButtonClick();
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;

            Assert.AreNotEqual(expected: 0, actual: colorScript.textNumOfClicks);
        }
    }
}
