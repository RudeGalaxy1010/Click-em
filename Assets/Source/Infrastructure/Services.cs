using System;
using System.Collections.Generic;
using UnityEngine;

namespace Source.Infrastructure {
    public class Services {
        private readonly Dictionary<Type, object> _services;
        private static Services _instance;
        
        private Services() {
            _services = new Dictionary<Type, object>(32);
        }
        
        public static Services Container => _instance ??= new Services();
        public TService Single<TService>() where TService : IService => (TService)_services[typeof(TService)];

        public TService RegisterSingle<TService>(TService implementation) where TService : IService {
            Type type = typeof(TService);
            
            if (_services.TryGetValue(type, out object service)) {
                Debug.LogError($"Service {type} already registered!");
                return (TService)service;
            }

            _services[type] = implementation;
            return implementation;
        }
    }
}
