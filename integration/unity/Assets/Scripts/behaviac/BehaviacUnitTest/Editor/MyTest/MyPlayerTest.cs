using agent;
using behaviac;
using NUnit.Framework;
using UnityEngine;

namespace MyTest
{
    /// <summary>
    /// 定义一个自己的test
    /// </summary>
    [TestFixture]
    [Category("MyPlayerTest")]
    public class MyPlayerTest
    {
        private MyPlayer testAgent;
        
        [TestFixtureSetUp]
        public void initTest()
        {
            BehaviacSystem.Instance.Init();
            
            GameObject testAgentObject = new GameObject();
            testAgentObject.name = "@UnitTestAgent";
            testAgentObject.transform.localPosition = Vector3.zero;
            testAgentObject.transform.localRotation = Quaternion.identity;
            testAgentObject.transform.localScale = Vector3.one;
            testAgent = testAgentObject.AddComponent<MyPlayer>();
        }
        
        [TestFixtureTearDown]
        public void finlTest()
        {
            BehaviacSystem.Instance.Uninit();
        }

        [Test]
        [Category("testMove")]
        public void testMove()
        {
            testAgent.btsetcurrent("mytest/test_moving");     
            behaviac.EBTStatus status = testAgent.btexec();
            behaviac.Debug.Log($"status {status}");
        }
        
        [SetUp]
        public void initTestEnv()
        {
        }

        [TearDown]
        public void finlTestEnv()
        {
            behaviac.Workspace.Instance.UnLoadAll();
        }
    }
}