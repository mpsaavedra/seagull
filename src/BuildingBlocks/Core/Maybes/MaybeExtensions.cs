using System;

namespace Seagull;

/// <summary>
/// Contains extension methods for the maybe class.
/// </summary>
public static class MaybeExtensions
{
    /// <summary>
    /// Binds to the result of the function and returns it.
    /// </summary>
    /// <typeparam name="TIn">The result type.</typeparam>
    /// <typeparam name="TOut">The output result type.</typeparam>
    /// <param name="maybe">The maybe value.</param>
    /// <param name="func">The bind function.</param>
    /// <returns>
    /// The bound value if the maybe has a value, otherwise an empty maybe instance.
    /// </returns>
    public static async Task<Maybe<TOut>> Bind<TIn, TOut>(this Maybe<TIn> maybe, Func<TIn, Task<Maybe<TOut>>> func) =>
        maybe.HasValue ? await func(maybe.Value) : Maybe<TOut>.None;

    /// <summary>
    /// Matches to the corresponding functions based on existence of the value.
    /// </summary>
    /// <typeparam name="TIn">The input type.</typeparam>
    /// <typeparam name="TOut">The output type.</typeparam>
    /// <param name="resultTask">The maybe task.</param>
    /// <param name="onSuccess">The on-success function.</param>
    /// <param name="onFailure">The on-failure function.</param>
    /// <returns>
    /// The result of the on-success function if the maybe has a value, otherwise the result of the failure result.
    /// </returns>
    public static async Task<TOut> Match<TIn, TOut>(
        this Task<Maybe<TIn>> resultTask,
        Func<TIn, TOut> onSuccess,
        Func<TOut> onFailure)
    {
        Maybe<TIn> maybe = await resultTask;

        return maybe.HasValue ? onSuccess(maybe.Value) : onFailure();
    }

    public static async Task<T> Bind<T>(this Task<T> task, Func<T, T> func)
    {
        var result = await task;
        return func(result);
    }

    public static async Task<T> BindAsync<T>(this Task<T> task, Func<T, Task<T>> func)
    {
        var result = await task;
        return await func(result);
    }

    public static async Task<TResult> Map<T, TResult>(this Task<T> task, Func<T, TResult> func)
    {
        var result = await task;
        return func(result);
    }


    public static async Task<Maybe<T>> Bind<T>(this Task<Maybe<T>> task, Func<T, Maybe<T>> func)
    {
        var maybe = await task;
        // Si ya viene como None, propagamos el None sin ejecutar la función
        return maybe.HasValue ? func(maybe.Value) : Maybe<T>.None;
    }

    public static async Task<Maybe<T>> BindAsync<T>(this Task<Maybe<T>> task, Func<T, Task<Maybe<T>>> func)
    {
        var maybe = await task;
        return maybe.HasValue ? await func(maybe.Value) : Maybe<T>.None;
    }

    public static async Task<TResult> Map<T, TResult>(this Task<Maybe<T>> task, Func<T, TResult> onSuccess, Func<TResult> onNone)
    {
        var maybe = await task;
        return maybe.HasValue ? onSuccess(maybe.Value) : onNone();
    }

}

