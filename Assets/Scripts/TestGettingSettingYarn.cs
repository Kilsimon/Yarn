using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Unity.Example;

public class TestGettingSettingYarn : MonoBehaviour
{
    public GameObject Test;
    private string testString;
    // Update is called once per frame
    void Update()
    {
        VariableStorage varStore = Test.GetComponent<VariableStorage>();

        testString = varStore.GetValue("$varToGet").AsString;
        Debug.Log(testString);
    }
}
