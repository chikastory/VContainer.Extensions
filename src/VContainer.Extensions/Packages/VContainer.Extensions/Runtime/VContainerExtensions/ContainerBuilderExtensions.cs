using System;
using System.Runtime.CompilerServices;

namespace VContainer {
    public static class ContainerBuilderExtensions {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegister(
            this IContainerBuilder builder,
            Type type,
            Lifetime lifetime) {
            if (builder.Exists(type)) return false;
            builder.Register(type, lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegister<T>(
            this IContainerBuilder builder,
            Lifetime lifetime) {
            if (builder.Exists(typeof(T))) return false;
            builder.Register<T>(lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegister<TInterface, TImplement>(
            this IContainerBuilder builder,
            Lifetime lifetime)
            where TImplement : TInterface {
            if (builder.Exists(typeof(TInterface))) return false;
            builder.Register<TInterface, TImplement>(lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegister<TInterface1, TInterface2, TImplement>(
            this IContainerBuilder builder,
            Lifetime lifetime)
            where TImplement : TInterface1, TInterface2 {
            if (builder.Exists(typeof(TInterface1))) return false;
            if (builder.Exists(typeof(TInterface2))) return false;
            builder.Register<TInterface1, TInterface2, TImplement>(lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegister<TInterface1, TInterface2, TInterface3, TImplement>(
            this IContainerBuilder builder,
            Lifetime lifetime)
            where TImplement : TInterface1, TInterface2, TInterface3 {
            if (builder.Exists(typeof(TInterface1))) return false;
            if (builder.Exists(typeof(TInterface2))) return false;
            if (builder.Exists(typeof(TInterface3))) return false;
            builder.Register<TInterface1, TInterface2, TInterface3, TImplement>(lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegister<TInterface>(
            this IContainerBuilder builder,
            Func<IObjectResolver, TInterface> implementationConfiguration,
            Lifetime lifetime)
            where TInterface : class {
            if (builder.Exists(typeof(TInterface))) return false;
            builder.Register(implementationConfiguration, lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterInstance<TInterface>(
            this IContainerBuilder builder,
            TInterface instance) {
            if (builder.Exists(typeof(TInterface))) return false;
            builder.RegisterInstance(instance);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterInstance<TInterface1, TInterface2>(
            this IContainerBuilder builder,
            TInterface1 instance) {
            if (builder.Exists(typeof(TInterface1))) return false;
            if (builder.Exists(typeof(TInterface2))) return false;
            builder.RegisterInstance(instance).As(typeof(TInterface1), typeof(TInterface2));
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterInstance<TInterface1, TInterface2, TInterface3>(
            this IContainerBuilder builder,
            TInterface1 instance) {
            if (builder.Exists(typeof(TInterface1))) return false;
            if (builder.Exists(typeof(TInterface2))) return false;
            if (builder.Exists(typeof(TInterface3))) return false;
            builder.RegisterInstance(instance).As(typeof(TInterface1), typeof(TInterface2), typeof(TInterface3));
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<T>(
            this IContainerBuilder builder,
            Func<T> factory) =>
            builder.TryRegisterInstance(factory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, T>(
            this IContainerBuilder builder,
            Func<TParam1, T> factory) =>
            builder.TryRegisterInstance(factory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, TParam2, T>(
            this IContainerBuilder builder,
            Func<TParam1, TParam2, T> factory) =>
            builder.TryRegisterInstance(factory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, TParam2, TParam3, T>(
            this IContainerBuilder builder,
            Func<TParam1, TParam2, TParam3, T> factory) =>
            builder.TryRegisterInstance(factory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, TParam2, TParam3, TParam4, T>(
            this IContainerBuilder builder,
            Func<TParam1, TParam2, TParam3, TParam4, T> factory) =>
            builder.TryRegisterInstance(factory);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<T>(
            this IContainerBuilder builder,
            Func<IObjectResolver, Func<T>> factoryFactory,
            Lifetime lifetime) {
            if (builder.Exists(typeof(Func<T>))) return false;
            builder.RegisterFactory(factoryFactory, lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, T>(
            this IContainerBuilder builder,
            Func<IObjectResolver, Func<TParam1, T>> factoryFactory,
            Lifetime lifetime) {
            if (builder.Exists(typeof(Func<TParam1, T>))) return false;
            builder.RegisterFactory(factoryFactory, lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, TParam2, T>(
            this IContainerBuilder builder,
            Func<IObjectResolver, Func<TParam1, TParam2, T>> factoryFactory,
            Lifetime lifetime) {
            if (builder.Exists(typeof(Func<TParam1, TParam2, T>))) return false;
            builder.RegisterFactory(factoryFactory, lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, TParam2, TParam3, T>(
            this IContainerBuilder builder,
            Func<IObjectResolver, Func<TParam1, TParam2, TParam3, T>> factoryFactory,
            Lifetime lifetime) {
            if (builder.Exists(typeof(Func<TParam1, TParam2, TParam3, T>))) return false;
            builder.RegisterFactory(factoryFactory, lifetime);
            return true;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryRegisterFactory<TParam1, TParam2, TParam3, TParam4, T>(
            this IContainerBuilder builder,
            Func<IObjectResolver, Func<TParam1, TParam2, TParam3, TParam4, T>> factoryFactory,
            Lifetime lifetime) {
            if (builder.Exists(typeof(Func<TParam1, TParam2, TParam3, TParam4, T>))) return false;
            builder.RegisterFactory(factoryFactory, lifetime);
            return true;
        }
    }
}
