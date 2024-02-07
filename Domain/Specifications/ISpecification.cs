﻿namespace Domain.Specifications;

public interface ISpecification<in T>
{
    bool IsSatisfied(T obj);
}