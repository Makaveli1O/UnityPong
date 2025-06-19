using System;
using System.Collections.Generic;

namespace Assets.Scripts.SharedKernel
{
    public static class SimpleServiceLocator
    {
        private static readonly Dictionary<Type, object> _services = new();

        public static void Register<T>(T service) where T : class => _services[typeof(T)] = service;

        public static T Resolve<T>() where T : class => _services[typeof(T)] as T;
        public static void Clear() => _services.Clear();
    }
}
