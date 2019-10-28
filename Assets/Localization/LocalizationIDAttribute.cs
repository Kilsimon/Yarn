using UnityEngine;
using System.Collections;
using System;

namespace BrokenWindow.Localization
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
    public class LocalizationIDAttribute : PropertyAttribute
    {
    }
}
