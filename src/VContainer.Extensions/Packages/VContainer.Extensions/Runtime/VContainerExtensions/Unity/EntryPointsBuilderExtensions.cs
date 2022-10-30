using System.Reflection;
using System.Runtime.CompilerServices;

namespace VContainer.Unity {
    public static class EntryPointsBuilderExtensions {
        static readonly FieldInfo ContainerBuilderField =
            typeof(EntryPointsBuilder).GetField("containerBuilder", BindingFlags.Instance | BindingFlags.NonPublic);

        static readonly FieldInfo LifetimeField =
            typeof(EntryPointsBuilder).GetField("lifetime", BindingFlags.Instance | BindingFlags.NonPublic);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static IContainerBuilder GetContainerBuilder(this EntryPointsBuilder source) =>
            (IContainerBuilder)ContainerBuilderField.GetValue(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static Lifetime GetLifetime(this EntryPointsBuilder source) =>
            (Lifetime)LifetimeField.GetValue(source);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryAdd<T>(this EntryPointsBuilder source) {
            var builder = source.GetContainerBuilder();
            if (builder.Exists(typeof(T))) return false;
            var lifetime = source.GetLifetime();
            builder.Register<T>(lifetime).AsImplementedInterfaces();
            return true;
        }
    }
}
