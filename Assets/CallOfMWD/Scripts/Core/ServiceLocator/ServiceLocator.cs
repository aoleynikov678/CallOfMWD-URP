using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace lab.core
{
    /// <summary>
    /// Simple service locator for <see cref="IGameService"/> instances.
    /// </summary>
    public class ServiceLocator
    {
        private ServiceLocator() { }

        /// <summary>
        /// currently registered services.
        /// </summary>
        private readonly Dictionary<string, IGameService> services = new Dictionary<string, IGameService>();
        
        private readonly List<IDisposable> disposables = new List<IDisposable>();
        private readonly List<ITickable> tickables = new List<ITickable>();
        private readonly List<IInitializable> initializables = new List<IInitializable>();

        /// <summary>
        /// Gets the currently active service locator instance.
        /// </summary>
        public static ServiceLocator Current { get; private set; }

        /// <summary>
        /// Initalizes the service locator with a new instance.
        /// </summary>
        public static void Create()
        {
            Current = new ServiceLocator();
        }

        /// <summary>
        /// Gets the service instance of the given type.
        /// </summary>
        /// <typeparam name="T">The type of the service to lookup.</typeparam>
        /// <returns>The service instance.</returns>
        public T Get<T>() where T : IGameService
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                Debug.LogError($"{key} not registered with {GetType().Name}");
                throw new InvalidOperationException();
            }

            return (T)services[key];
        }

        /// <summary>
        /// Registers the service with the current service locator.
        /// </summary>
        /// <typeparam name="T">Service type.</typeparam>
        /// <param name="service">Service instance.</param>
        public IGameService Register<T>(T service) where T : IGameService
        {
            string key = typeof(T).Name;
            if (services.ContainsKey(key))
            {
                Debug.LogError($"Attempted to register service of type {key} which is already registered with the {GetType().Name}.");
                return null;
            }

            services.Add(key, service);
            
            // TODO refactor
            Type systemType = service.GetType();
            List<Type> interfaces = systemType.GetInterfaces().ToList();

            
            if (interfaces.Contains(typeof(IDisposable)))
            {
                if (disposables.Contains((IDisposable) service) == false)
                {
                    disposables.Add((IDisposable) service);
                }
            }
            
            if (interfaces.Contains(typeof(ITickable)))
            {
                if (tickables.Contains((ITickable) service) == false)
                {
                    tickables.Add((ITickable) service);
                }
            }
            
            if (interfaces.Contains(typeof(IInitializable)))
            {
                if (initializables.Contains((IInitializable) service) == false)
                {
                    initializables.Add((IInitializable) service);
                }
            }

            return service;
        }

        /// <summary>
        /// Unregisters the service from the current service locator.
        /// </summary>
        /// <typeparam name="T">Service type.</typeparam>
        public void Unregister<T>() where T : IGameService
        {
            string key = typeof(T).Name;
            if (!services.ContainsKey(key))
            {
                Debug.LogError($"Attempted to unregister service of type {key} which is not registered with the {GetType().Name}.");
                return;
            }

            services.Remove(key);
        }

        public void Initialize()
        {
            foreach (var initializable in initializables)
            {
                initializable.Initialize();
            }
        }

        public void Tick()
        {
            foreach (var tickable in tickables)
            {
                tickable.Tick();
            }
        }

        public void Dispose()
        {
            foreach (var disposable in disposables)
            {
                Attribute[] attrs = Attribute.GetCustomAttributes(disposable.GetType());

                foreach (var attr in attrs)
                {
                    if (attr is AutoDisposeAttribute)
                    {
                        AutoDisposeAttribute a = (AutoDisposeAttribute) attr;

                        var fields = disposable.GetType().GetFields();

                        foreach (var field in fields)
                        {
                            if (field.FieldType == a.TypeToDispose)
                            {
                                object val = field.GetValue(disposable);
                                Debug.Log("AUTO DISPOSE " + field.Name);
                                val = null;
                            }
                            else if (field.FieldType.IsGenericType && field.FieldType.GetGenericTypeDefinition() == a.TypeToDispose)
                            {
                                object val = field.GetValue(disposable);
                                Debug.Log("AUTO DISPOSE " + field.Name);
                                val = null;
                            }
                        }
                    }
                }

                
                disposable.Dispose();
            }
        }
    }
}