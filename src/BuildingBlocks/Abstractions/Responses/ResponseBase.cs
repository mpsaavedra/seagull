using System;

namespace Seagull.Abstractions.Responses;

/// <summary>
/// A response that returns only information about the response status,
/// if was successed or not, if not should return the error(s)
/// </summary>
public record Response
{
    /// <summary>
    /// gets trus if response was successfull
    /// </summary>
    public bool Success { get; protected set; } = true;
    /// <summary>
    /// main error message if any
    /// </summary>
    public string? Message { get; protected set; }
    /// <summary>
    /// gets the list of errors if any
    /// </summary>
    public List<string> Errors { get; protected set; } = [];

    /// <summary>
    /// returns a new <see cref="Response"/> instance
    /// </summary>
    /// <param name="success"></param>
    /// <param name="message"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static Response Create(bool success = true, string? message = null, List<string>? errors = null) =>
        new Response
        {
            Success = success,
            Message = message,
            Errors = errors is not null ? errors : []
        };

    /// <summary>
    /// adds a new error to the list of errors
    /// </summary>
    /// <param name="error"></param>
    /// <returns></returns>
    public Response AddError(string error)
    {
        if (!Errors.Contains(error))
            Errors.Add(error);
        return this;
    }
}

/// <summary>
/// A response that contains data of provided type
/// </summary>
/// <typeparam name="T"></typeparam>
public record Response<T> : Response
{
    public T? Data { get; set; }

    /// <summary>
    /// return a new <see cref="Response{T}"/> instance
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="success"></param>
    /// <param name="message"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static Response<T> Create(T? data = default, bool success = true, string? message = null,
        List<string>? errors = null) =>
        new Response<T>
        {
            Data = data,
            Success = success,
            Message = message,
            Errors = errors is not null ? errors : []
        };
}

/// <summary>
/// Reponse used when query paginated data
/// </summary>
/// <typeparam name="T"></typeparam>
public record PaginatedResponse<T> : Response
{
    /// <summary>
    /// gets if data has any previous page
    /// </summary>
    public bool HasPreviousPage { get; private set; } = false;
    /// <summary>
    /// gets if data has more pages or not
    /// </summary>
    public bool HasNextPage { get; private set; } = false;
    /// <summary>
    /// gets the returned data of response
    /// </summary>
    public IQueryable<T>? Data { get; private set; } = new List<T>().AsQueryable();

    /// <summary>
    /// returns a new <see cref="PaginatedResponse"/> instance
    /// </summary>
    /// <param name="data"></param>
    /// <param name="success"></param>
    /// <param name="message"></param>
    /// <param name="errors"></param>
    /// <returns></returns>
    public static PaginatedResponse<T> Create(IQueryable<T>? data, bool success = true, string? message = null, List<string>? errors = null) =>
        new PaginatedResponse<T>
        {
            Data = data,
            Success = success,
            Message = message,
            Errors = errors is not null ? errors : []
        };
}
