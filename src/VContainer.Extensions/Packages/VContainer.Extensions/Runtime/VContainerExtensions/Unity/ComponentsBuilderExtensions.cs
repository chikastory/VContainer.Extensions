using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace VContainer.Unity {
    public static class ComponentsBuilderExtensions {
        static readonly FieldInfo ContainerBuilderField =
            typeof(ComponentsBuilder).GetField("containerBuilder", BindingFlags.Instance | BindingFlags.NonPublic);

        static readonly FieldInfo ParentTransformField =
            typeof(ComponentsBuilder).GetField("parentTransform", BindingFlags.Instance | BindingFlags.NonPublic);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IContainerBuilder GetContainerBuilder(this ComponentsBuilder source) =>
            (IContainerBuilder)ContainerBuilderField.GetValue(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Transform GetParentTransform(this ComponentsBuilder source) =>
            (Transform)ParentTransformField.GetValue(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAddInstance<TInterface>(this ComponentsBuilder source, TInterface component) {
            var builder = source.GetContainerBuilder();
            if (builder.Exists(typeof(TInterface))) return false;
            builder.RegisterComponent(component);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAddInHierarchy<T>(this ComponentsBuilder source) {
            var builder = source.GetContainerBuilder();
            if (builder.Exists(typeof(T))) return false;
            var parent = source.GetParentTransform();
            builder.RegisterComponentInHierarchy<T>().UnderTransform(parent);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAddOnNewGameObject<T>(this ComponentsBuilder source, Lifetime lifetime,
            string newGameObjectName = null)
            where T : Component {
            var builder = source.GetContainerBuilder();
            if (builder.Exists(typeof(T))) return false;
            var parent = source.GetParentTransform();
            builder.RegisterComponentOnNewGameObject<T>(lifetime, newGameObjectName).UnderTransform(parent);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAddInNewPrefab<T>(this ComponentsBuilder source, T prefab, Lifetime lifetime)
            where T : Component {
            var builder = source.GetContainerBuilder();
            if (builder.Exists(typeof(T))) return false;
            var parent = source.GetParentTransform();
            builder.RegisterComponentInNewPrefab(prefab, lifetime).UnderTransform(parent);
            return true;
        }
    }
}
