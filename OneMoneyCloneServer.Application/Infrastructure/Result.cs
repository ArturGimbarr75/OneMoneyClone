namespace OneMoneyCloneServer.Application.Infrastructure;

public class Result<T, TError> where TError : struct, Enum
{
	public T? Value { get; set; }
	public TError? Error { get; set; }

	public static implicit operator bool(Result<T, TError> rhs)
	{
		return rhs.Error is null;
	}

	public static implicit operator Result<T, TError>(T res) => new()
	{
		Value = res
	};

	public static implicit operator Result<T, TError>(TError error) => new()
	{
		Error = error
	};

	public static Result<T, TError> Ok(T val) => val;
	public static Result<T, TError> WithError(TError error) => error;
}

public class Result<TError> where TError : struct, Enum
{
	public TError? Error { get; set; }

	public static implicit operator bool(Result<TError> rhs)
	{
		return rhs.Error is null;
	}

	public static implicit operator Result<TError>(TError error) => new()
	{
		Error = error
	};
}

public static class Result
{
	public static Result<TError> Ok<TError>() where TError : struct, Enum
	{
		return new Result<TError>();
	}
}
