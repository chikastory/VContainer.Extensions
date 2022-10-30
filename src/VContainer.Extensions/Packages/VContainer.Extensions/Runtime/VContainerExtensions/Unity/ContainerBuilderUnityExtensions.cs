using System.Runtime.CompilerServices;
using UnityEngine;

namespace VContainer.Unity {
    public static class ContainerBuilderExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterEntryPoint<T>(this IContainerBuilder builder,
            Lifetime lifetime = Lifetime.Singleton) {
            if (builder.Exists(typeof(T))) return false;
            builder.RegisterEntryPoint<T>(lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterComponent<TInterface>(this IContainerBuilder builder,
            TInterface component) {
            if (builder.Exists(typeof(TInterface))) return false;
            builder.RegisterComponent(component);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterComponentInHierarchy<T>(this IContainerBuilder builder) {
            if (builder.Exists(typeof(T))) return false;
            builder.RegisterComponentInHierarchy<T>();
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterComponentOnNewGameObject<T>(
            this IContainerBuilder builder,
            Lifetime lifetime,
            string newGameObjectName = null)
            where T : Component {
            if (builder.Exists(typeof(T))) return false;
            builder.RegisterComponentOnNewGameObject<T>(lifetime, newGameObjectName);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterComponentInNewPrefab<T>(
            this IContainerBuilder builder,
            T prefab,
            Lifetime lifetime)
            where T : Component {
            if (builder.Exists(typeof(T))) return false;
            builder.RegisterComponentInNewPrefab(prefab, lifetime);
            return true;
        }
    }
}
