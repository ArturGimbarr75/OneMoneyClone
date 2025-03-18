namespace OneMoneyCloneServer.Application.Infrastructure;

public class InfoResult<T, TError> : Result<T, TError> where TError : struct, Enum
{
	public IEnumerable<string> Info { get; set; } = default!;

	public static implicit operator InfoResult<T, TError>(T res)
	{
		return new InfoResult<T, TError>
		{
			Value = res
		};
	}

	public static implicit operator InfoResult<T, TError>(TError error)
	{
		return new InfoResult<T, TError>
		{
			Error = error
		};
	}

	public static InfoResult<T, TError> WithInfo(TError error, params IEnumerable<string> info)
	{
		return new InfoResult<T, TError>
		{
			Error = error,
			Info = info
		};
	}

	public static InfoResult<T, TError> Ok(T val, params IEnumerable<string> info)
	{
		return new InfoResult<T, TError>
		{
			Value = val,
			Info = info
		};
	}
}