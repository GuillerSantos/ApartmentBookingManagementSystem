using System.Diagnostics.CodeAnalysis;

namespace ApartmentBookingManagementSystem.Domain.Abstractions;

public class Result
{
    #region Protected Internal Constructors

    protected internal Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    #endregion Protected Internal Constructors

    #region Properties

    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; }

    #endregion Properties

    #region Public Methods

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

    public static Result<TValue> Create<TValue>(TValue? value) =>
        value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

    #endregion Public Methods
}

public class Result<TValue> : Result
{
    #region Fields

    private readonly TValue? _value;

    #endregion Fields

    #region Protected Internal Constructors

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    #endregion Protected Internal Constructors

    #region Properties

    [NotNull]
    public TValue Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException("The Value Of A Failure Result Can Not Be Accessed.");

    #endregion Properties

    #region Public Methods

    public static implicit operator Result<TValue>(TValue? value) => Create(value);

    #endregion Public Methods
}