using System;

namespace Plugins.DI
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Method)]
    public class InjectAttribute : Attribute
    {
    }
}