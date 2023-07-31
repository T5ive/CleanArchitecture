namespace CleanArchitecture.Application.Common.Models;

public class Result
{
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }
    public static Result Failure(string error)
    {
        return new Result(false, new List<string> { error });
    }
    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
}

public class Result<T>
{
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }
    internal Result(bool succeeded, IEnumerable<string> errors, T? data)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
        Data = data;
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public T? Data { get; set; }

    public static Result<T> Success(T data)
    {
        return new Result<T>(true, Array.Empty<string>(), data);
    }
    public static Result<T> Failure(string error)
    {
        return new Result<T>(false, new List<string> { error });
    }
    public static Result<T> Failure(IEnumerable<string> errors)
    {
        return new Result<T>(false, errors);
    }
    public static Result<T> Failure(string error, T? data)
    {
        return new Result<T>(false, new List<string> { error }, data);
    }
    public static Result<T> Failure(IEnumerable<string> errors, T? data)
    {
        return new Result<T>(false, errors, data);
    }
}
