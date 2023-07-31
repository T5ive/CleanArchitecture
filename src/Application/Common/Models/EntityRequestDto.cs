﻿namespace CleanArchitecture.Application.Common.Models;

public abstract record EntityRequestDto<T>
{
    public T? Id { get; init; }
}
